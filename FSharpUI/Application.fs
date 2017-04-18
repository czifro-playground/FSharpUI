namespace FSharpUI

  open DevZH.UI
  open DevZH.UI.Events
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module Application =

    let createApplication hiddenConsole =
      let hiddenConsole = defaultArg hiddenConsole true
      new Application(hiddenConsole)

    let currentApplication() = Application.Current

    let hideConsole (app:Application) =
      app.HideConsole <- true
      app

    let run window (app:Application) =
      app.Run(window)

    let queueMain (action:unit->unit) =
      Application.QueueMain(System.Action(action))

    let exitApplication (app:Application) =
      app.Exit()
      app
    
    let disposeApplication (app:Application) =
      app.Dispose()
      app

    let exitAndDisposeApplication app =
      app |> (exitApplication >> disposeApplication)