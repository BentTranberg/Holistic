module Holistic.Models.MainWindow

open Elmish
open Elmish.WPF

type Model =
    {
        Reply: string
    }

type Msg =
    | SayHello

let startModel =
    {
        Reply = "Waiting for reply"
    }

let init () = startModel, Cmd.none

let update (msg: Msg) (m: Model) : Model * Cmd<Msg> =
    match msg with
    | SayHello -> { m with Reply = "Hello, world!" }, Cmd.none

let bindings () : Binding<Model,Msg> list = [
    "SayHello" |> Binding.cmd SayHello
    "Reply" |> Binding.oneWay (fun m -> m.Reply)
    ]

let designVm = ViewModel.designInstance startModel (bindings ())
