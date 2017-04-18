namespace FSharpUI.MouseControls

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module ColorPicker =

    let createColorPicker() =
      new ColorPicker()

    let color (colorPicker:ColorPicker) =
      colorPicker.Color

    let setColor color (colorPicker:ColorPicker) =
      colorPicker.Color <- color
      colorPicker

  [<AutoOpen>]
  module DateTimePicker =

    type ITypes =
      | DateTimePicker
      | DatePicker
      | TimePicker

    let createDateTimePicker (type':ITypes) : Control =
      match type' with
      | ITypes.DateTimePicker -> new DateTimePicker() :> Control
      | ITypes.DatePicker -> new DatePicker() :> Control
      | ITypes.TimePicker -> new TimePicker() :> Control

  [<AutoOpen>]
  module FontPicker =

    let createFontPicker() =
      new FontPicker()

    let font (fontPicker:FontPicker) =
      fontPicker.Font