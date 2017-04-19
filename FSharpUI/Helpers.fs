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

    let inline create<'a> (x:obj) =
      let argsOption = tryTupleToArray x
      let args =
        if argsOption.IsSome then argsOption.Value
        else [| x |]
      let argTypes =
        args
        |> Array.map(fun o ->
          let t = o.GetType()
          if t.Name.ToLower() = "unit" then typeof<Void> else t
        )
      getInstance<'a> argTypes args

    let inline addOnEvent<'a when 'a :> EventArgs> onEvent (o:obj) =
      let e = IOnEvent<'a>(onEvent)
      let eventName =
        match o with
        | :? Button | :? CheckBox | :? MenuItem -> "Click"
        | :? ComboBox | :? RadioButtonList -> "Selected"
        | :? EditableComboBox -> "TextChanged"
        | :? Slider | :? SpinBox -> "ValueChanged"
        | :? ColorPicker -> "ColorChanged"
        | :? FontPicker -> "FontChanged"
        | :? Application -> "OnShouldExit"
        | :? Control -> failwith "Type 'Control' has multiple events, cannot discriminate"
        | _ -> failwithf "Type '%s' is not supported" ((getType o).ToString())
      addEvent<'a> eventName o e
      |> cast<'a>