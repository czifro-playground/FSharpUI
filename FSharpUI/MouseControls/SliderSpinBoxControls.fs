namespace FSharpUI.MouseControls

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module Slider =

    // adding to ValueChanged is handled in Shared module

    let createSlider min max =
      new Slider(min,max)

    let sliderValue (slider:Slider) =
      slider.Value

    let setSliderValue v (slider:Slider) =
      slider.Value <- v
      slider