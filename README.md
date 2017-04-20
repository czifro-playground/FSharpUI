# FSharpUI
An F# lib that wraps DevZH.UI to provide a functional way of creating GUI apps in F#

## What is supported?
Well technically everything as long as you use both this project and DevZH.UI. As an F# standalone, I will first need to type alias everything before I can truly say this is standalone. However, what has currently been wrapped is `Application`, `Control`, a set of mouse based controls: `Button`, `CheckBox`, `ComboBox`, `EditableComboBox` (which is also a keyboard control), `ColorPicker`, `DatePicker`, `DateTimePicker`, `TimePicker`, `FontPicker`, `Menu`, `MenuItem`, `RadioButtonList`, `Slider`, `SpinBox`, and a set of keyboard based controls: `EditableComboBox`, `EntryBase` (and all sub types), and `MultilineEntry`. The other controls are not yet supported. However, all types should be instantiable using `create<'Type> argsTuple`, supports using just `()`.

I'm working hard to get everything else supported. Drawing will likely take the longest to support as it is a very large chunk of DevZH.UI and I want to try and reduce all redundancies to provide a clean API.