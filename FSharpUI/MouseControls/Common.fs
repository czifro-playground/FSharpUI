namespace FSharpUI.MouseControls

  open System
  open System.Reflection
  open DevZH.UI
  open FSharpUI
  open FSharpUI.Internal.Reflection

  [<AutoOpen>]
  module Common =

    let inline text<'a when 'a :> Control> (control:'a) =
      match (getType control).Name with
      | "ButtonBase" | "EditableComboBox" ->
        getPropertyValue "Text" control
        |> cast<string>
      | _ -> failwith "This control does not have text"

    let inline setText<'a when 'a :> Control> text (control:'a) =
      match (getType control).Name with
      | "ButtonBase" | "EditableComboBox" ->
        setPropertyValue "Text" control text
        |> cast<'a>
      | _ -> failwith "This control does not have setable text"

    let inline private setCheck<'a when 'a :> Control> toggle (control:'a) =
      match (getType control).Name with
      | "CheckBox" | "MenuItem" -> 
        setPropertyValue "IsChecked" control toggle
        |> cast<'a>
      | _ -> failwith "This control cannot be checked"

    let inline check control = setCheck true control

    let inline uncheck control = setCheck false control

    let inline addText<'a when 'a :> Control> (text:string[]) (control:'a) =
      let text = text |> Array.map(fun s -> s :> obj)
      match (getType control).Name with
      | "ComboBox" | "EditableComboBox" ->
        let add = getMethod "Add" control [| typeof<array<string>> |]
        add.Invoke(control, text) |> ignore
        control
      | _ -> failwith "This control needs to be a ComboBox or EditableComboBox"
