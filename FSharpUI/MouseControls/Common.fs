namespace FSharpUI.MouseControls

  open System
  open System.ComponentModel
  open System.Runtime.InteropServices
  open System.Reflection
  open DevZH.UI.Events
  open DevZH.UI
  open FSharpUI.Internal.Events
  open FSharpUI.Internal.Reflection

  [<AutoOpen>]
  module Common =

    let text (control:Control) =
      match control with
      | :? ButtonBase as button -> button.Text
      | :? EditableComboBox as ecb -> ecb.Text
      | _ -> failwith "This control does not have text"

    let setText text (control:Control) =
      match control with
      | :? ButtonBase as button -> button.Text <- text
      | :? EditableComboBox as ecb -> ecb.Text <- text
      | _ -> failwith "This control does not have setable text"
      control

    let private setCheck toggle (control:Control) =
      match control with
      | :? CheckBox as cb -> cb.IsChecked <- toggle
      | :? MenuItem as mi -> mi.IsChecked <- toggle
      | _ -> failwith "This control cannot be checked"
      control

    let check control = setCheck true control

    let uncheck control = setCheck false control

    let addText text (control:Control) =
      match control with
      | :? ComboBox as cb -> cb.Add(text)
      | :? EditableComboBox as ecb -> ecb.Add(text)
      | _ -> failwith "This control needs to be a ComboBox or EditableComboBox"
      control

    let addOnEvent<'a when 'a :> EventArgs> onEvent (o:obj) =
      let e = IOnEvent<'a>(onEvent)
      let eventName =
        match o with
        | :? Button | :? CheckBox | :? MenuItem -> "Click"
        | :? ComboBox -> "Selected"
        | :? EditableComboBox -> "TextChanged"
        | :? Slider | :? SpinBox -> "ValueChanged"
        | :? ColorPicker -> "ColorChanged"
        | :? FontPicker -> "FontChanged"
        | :? Application -> "OnShouldExit"
        | :? Control -> failwith "Type 'Control' has multiple events, cannot discriminate"
        | _ -> failwithf "Type '%s' is not supported" ((getType o).ToString())
      addEvent<'a> eventName o e
