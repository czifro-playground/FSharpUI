namespace FSharpUI.Test

open System
open FSharpUI
open DevZH.UI
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    let isUnitOrNone v =
      try
        (v.GetType()) |> ignore
        false
      with
      | _ -> true

    [<TestMethod>]
    member this.TestMethodPassing () =
        //printfn "%b" (isUnitOrNone ())
        let app = create<Application> ()
        Assert.IsTrue(true);
