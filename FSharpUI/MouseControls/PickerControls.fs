namespace FSharpUI.MouseControls

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module ColorPicker =

    let color (colorPicker:ColorPicker) =
      colorPicker.Color

    let setColor color (colorPicker:ColorPicker) =
      colorPicker.Color <- color
      colorPicker

  //[<AutoOpen>]
  //module DateTimePicker =


  [<AutoOpen>]
  module FontPicker =

    let font (fontPicker:FontPicker) =
      fontPicker.Font