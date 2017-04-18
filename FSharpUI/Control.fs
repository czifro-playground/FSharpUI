namespace FSharpUI

  open DevZH.UI
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module Control =

    let addLocationChangedEvent (onLocationChanged:System.EventArgs->unit) (control:Control) =
      control.LocationChanged.Add(onLocationChanged)
      control

    let addResizeEvent (onResizeEvent:System.EventArgs->unit) (control:Control) =
      control.Resize.Add(onResizeEvent)
      control

    let parent (control:Control) =
      control.Parent

    let index (control:Control) =
      control.Index

    let handle (control:Control) =
      control.Handle

    let isEnabled (control:Control) =
      control.Enabled

    let private setEnabled toggle (control:Control) =
      match control with
      | :? MenuItem as mi -> mi.Enabled <- toggle
      | _ -> control.Enabled <- toggle
      control

    let enable (control:Control) =
      setEnabled true control

    let disable (control:Control) =
      setEnabled false control

    let isVisible (control:Control) =
      control.Visible

    let private setVisibility toggle (control:Control) =
      control.Visible <- toggle
      control

    let show control = setVisibility true control
    let hide control = setVisibility false control

    let isTopLevel (control:Control) =
      control.TopLevel

    let disposeControl (control:Control) =
      control.Dispose()
