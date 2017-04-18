namespace FSharpUI.MouseControls

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module ComboBox =

    let createComboBox() =
      new ComboBox()

    let selectedIndex (comboBox:ComboBox) =
      comboBox.SelectedIndex

  [<AutoOpen>]
  module EditableComboBox =

    let createEditableComboBox() =
      new EditableComboBox()
