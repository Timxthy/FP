// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type Ticket = {seat:int; customer:string}

let mutable tickets = [for n in 1..10 -> {Ticket.seat = n; Ticket.customer = ""}]

let bookSeat seatNo name tickets = 
  tickets |> List.map (fun ticket ->
    if ticket.seat = seatNo then { ticket with customer = name }
    else ticket )


