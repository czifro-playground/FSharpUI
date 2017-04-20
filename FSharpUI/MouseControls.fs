namespace FSharpUI.MouseControls

  open System
  open DevZH.UI
  open FSharpUI

  [<AutoOpen>]
  module Menu =

    type MenuItemConfig =
      {
        name : string option;
        menuItemType : MenuItemTypes option;
        action : (nativeint->unit) option
      }

      static member Default =
        {
          name = None;
          menuItemType = None;
          action = None
        }

    let addMenuItem (config:MenuItemConfig) (menu:Menu) =
      let mType = defaultArg config.menuItemType MenuItemTypes.Common
      let action =
        if config.action.IsSome then System.Action<nativeint>(config.action.Value)
        else null
      if config.name.IsNone then
        let mType = if mType = MenuItemTypes.Common then MenuItemTypes.Quit else mType
        menu.Add(mType, action),menu
      else
        menu.Add(config.name.Value, mType, action),menu

    let addSeparator (menu:Menu) =
      menu.AddSeparator()
      menu

    let items (menu:Menu) =
      menu.Items

  [<AutoOpen>]
  module ColorPicker =

    let color (colorPicker:ColorPicker) =
      colorPicker.Color

    let setColor color (colorPicker:ColorPicker) =
      colorPicker.Color <- color
      colorPicker


  [<AutoOpen>]
  module FontPicker =

    let font (fontPicker:FontPicker) =
      fontPicker.Font