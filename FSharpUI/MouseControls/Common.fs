namespace FSharpUI.MouseControls

  open System
  open System.Reflection
  open DevZH.UI
  open FSharpUI
  open FSharpUI.Internal.Reflection

  [<AutoOpen>]
  module Common =

    let private getFailMessage str =
      sprintf "This control does not have a '%s' property" str

    let private get<'a when 'a :> Control> name (control:'a) typeNames =
      if typeNames |> Array.contains((getType control).Name) then
        getPropertyValue name control
      else failwith (getFailMessage name)

    let private set<'a when 'a :> Control> name (control:'a) v typeNames =
      if typeNames |> Array.contains((getType control).Name) then
        setPropertyValue name control v
      else failwith (getFailMessage name)

    let selectedIndex<'a when 'a :> Control> control =
      get "SelectedIndex" control [| "ComboBox"; "RadioButtonList" |]
      |> cast<int>

    let setSelectedIndex<'a when 'a :> Control> index control =
      set "SelectedIndex" control index [| "ComboBox"; "RadioButtonList" |]
      |> cast<'a>

    let text<'a when 'a :> Control> control =
      get "Text" control [| "ButtonBase"; "EditableComboBox" |]
      |> cast<string>

    let setText<'a when 'a :> Control> text control =
      set "Text" control text [| "ButtonBase"; "EditableComboBox" |]
      |> cast<'a>

    let value<'a when 'a :> Control> control =
      get "Value" control [| "Slider"; "SpinBox" |]
      |> cast<int>

    let setValue<'a when 'a :> Control> v control =
      set "Value" control v [| "Slider"; "SpinBox" |]
      |> cast<'a>

    let private setCheck<'a when 'a :> Control> toggle control =
      set "IsChecked" control toggle [| "CheckBox"; "MenuItem" |]
      |> cast<'a>

    let check control = setCheck true control

    let uncheck control = setCheck false control

    let addText<'a when 'a :> Control> (text:string[]) (control:'a) =
      let text = text |> Array.map(fun s -> s :> obj)
      match (getType control).Name with
      | "ComboBox" | "EditableComboBox" ->
        let add = getMethod "Add" control [| typeof<array<string>> |]
        add.Invoke(control, text) |> ignore
        control
      | _ -> failwith "This control needs to be a ComboBox or EditableComboBox"
