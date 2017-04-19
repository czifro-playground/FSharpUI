namespace FSharpUI.MouseControls

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module Slider =

    let sliderValue (slider:Slider) =
      slider.Value

    let setSliderValue v (slider:Slider) =
      slider.Value <- v
      slider