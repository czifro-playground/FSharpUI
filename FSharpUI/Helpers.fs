namespace FSharpUI

  open System
  open DevZH.UI
  open FSharpUI.Internal.Events
  open FSharpUI.Internal.Reflection

  [<AutoOpen>]
  module Helpers =

    let cast<'b> (o:obj) = (o :?> 'b)

    let applyTo<'b> (func:obj->obj) o =
      o |> (func >> cast<'b>)

    let create<'a> (x:obj) =
      let argsOption = tryTupleToArray x
      let args =
        if argsOption.IsSome then argsOption.Value
        elif isUnitOrNone x then [||]
        else [| x |]
      let argTypes =
        if Array.isEmpty args then [| typeof<Void> |]
        else args |> Array.map getType
      printfn "%A %A" args argTypes
      getInstance<'a> argTypes args

    let addOnEvent<'a when 'a :> EventArgs> onEvent (o:obj) =
      let e = IOnEvent<'a>(onEvent)
      let eventName =
        match o with
        | :? Button | :? CheckBox | :? MenuItem -> "Click"
        | :? ComboBox | :? RadioButtonList -> "Selected"
        | :? EditableComboBox | :? EntryBase -> "TextChanged"
        | :? Slider | :? SpinBox -> "ValueChanged"
        | :? ColorPicker -> "ColorChanged"
        | :? FontPicker -> "FontChanged"
        | :? Application -> "OnShouldExit"
        | :? Control -> failwith "Type 'Control' has multiple events, cannot discriminate"
        | _ -> failwithf "Type '%s' is not supported" ((getType o).ToString())
      addEvent<'a> eventName o e