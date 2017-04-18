namespace FSharpUI.MouseControls

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module Button =

    let createButton text =
      new Button(text)

  [<AutoOpen>]
  module CheckBox =

    let createCheckBox text =
      new CheckBox(text)
