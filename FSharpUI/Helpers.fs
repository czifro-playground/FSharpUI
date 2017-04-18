namespace FSharpUI

  [<AutoOpen>]
  module Helpers =

    let cast<'b> (o:obj) =
      (o :?> 'b)

    let applyTo<'b> (func:obj->obj) o =
      o |> (func >> cast<'b>)