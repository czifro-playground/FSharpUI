namespace FSharpUI

  open System
  open System.Reflection
  open DevZH.UI
  open FSharpUI
  open FSharpUI.Internal.Reflection

  module internal SharedInternal =
    let indexTypes =
      [| typeof<ComboBox>; typeof<RadioButtonList>; |]
    let textTypes =
      [| typeof<ButtonBase>; typeof<EntryBase>; 
        typeof<EditableComboBox>; typeof<MultilineEntry> |]
    let valueTypes =
      [| typeof<Slider>; typeof<SpinBox> |]
    let checkedTypes =
      [| typeof<CheckBox>; typeof<MenuItem> |]
    let readOnlyTypes =
      [| typeof<EntryBase>; typeof<MultilineEntry> |]

    let appendTypes =
      [| typeof<MultilineEntry> |]

  [<AutoOpen>]
  module Shared =

    [<AutoOpen>]
    module Property =

      let private getFailMessage str =
        sprintf "This control does not have a '%s' property" str

      let private get<'a when 'a :> Control> name (control:'a) types =
        if types |> Array.contains(getType control) then
          getPropertyValue name control
        else failwith (getFailMessage name)

      let private set<'a when 'a :> Control> name (control:'a) v types =
        if types |> Array.contains(getType control) then
          setPropertyValue name control v
        else failwith (getFailMessage name)

      let selectedIndex<'a when 'a :> Control> control =
        get "SelectedIndex" control SharedInternal.indexTypes
        |> cast<int>

      let setSelectedIndex<'a when 'a :> Control> index control =
        set "SelectedIndex" control index SharedInternal.indexTypes
        |> cast<'a>

      let text<'a when 'a :> Control> control =
        get "Text" control SharedInternal.textTypes
        |> cast<string>

      let setText<'a when 'a :> Control> text control =
        set "Text" control text SharedInternal.textTypes
        |> cast<'a>

      let value<'a when 'a :> Control> control =
        get "Value" control SharedInternal.valueTypes
        |> cast<int>

      let setValue<'a when 'a :> Control> v control =
        set "Value" control v SharedInternal.valueTypes
        |> cast<'a>

      let private setCheck<'a when 'a :> Control> toggle control =
        set "IsChecked" control toggle SharedInternal.checkedTypes
        |> cast<'a>

      let check control = setCheck true control

      let uncheck control = setCheck false control

      let isReadOnly<'a when 'a :> Control> control =
        get "IsReadOnly" control SharedInternal.readOnlyTypes
        |> cast<bool>

      let toggleReadOnly<'a when 'a :> Control> control =
        set "IsReadOnly" control (not <| isReadOnly control) SharedInternal.readOnlyTypes

    [<AutoOpen>]
    module Method =

      let private getFailMessage str =
        sprintf "This control does not have a '%s' method" str

      let private invoke name control argTypes args =
        let method = getMethod name control argTypes
        method.Invoke(control, args) |> ignore
        control

      let addText<'a when 'a :> Control> (text:string[]) (control:'a) =
        if SharedInternal.textTypes |> Array.contains(getType control) then
          invoke "Add" control [| typeof<array<string>> |] [| text |]
        else failwith (getFailMessage "Add")

      let appendText<'a when 'a :> Control> (text:string) (control:'a) =
        if SharedInternal.appendTypes |> Array.contains(getType control) then
          invoke "Append" control [| typeof<string> |] [| text |]
        else failwith (getFailMessage "Append")