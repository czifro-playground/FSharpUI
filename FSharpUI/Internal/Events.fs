namespace FSharpUI.Internal.Events

  [<AutoOpen>]
  module internal UI =

    type IOnEvent<'b> = delegate of 'b->unit