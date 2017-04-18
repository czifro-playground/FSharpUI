namespace FSharpUI.Internal.Reflection

  open System
  open System.Reflection
  open FSharpUI.Internal.Events

  [<AutoOpen>]
  module internal ReflectionUtil =

    let getType (o:obj) =
      o.GetType()

    let getProperty (name:string) (o:obj) =
      let t = getType o
      t.GetRuntimeProperty(name)

    let getPropertyValue (name:string) (o:obj) =
      let p = getProperty name o
      p.GetValue(o,null)

    let setPropertyValue (name:string) (o:obj) (v:obj) =
      let p = getProperty name o
      p.SetValue(o,v,null)
      o

    let getMethod (name:string) (o:obj) (paramTypes:Type[])=
      let t = getType o
      t.GetRuntimeMethod(name,paramTypes)

    let getEvent (name:string) (o:obj) =
      let t = getType o
      t.GetRuntimeEvent(name)

    let inline addEvent<'b when 'b :> EventArgs> (name:string) (o:obj) (onEvent:IOnEvent<'b>) =
      let e = getEvent name o
      e.AddEventHandler(o,onEvent)
      o