// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

 
  open System
  
  type Account(accountNumber : string, balance : float) =
      member this.AccountNumber = accountNumber
      member val Balance = balance with get, set
      
      member this.Withdraw (cash : float) =
          if cash > this.Balance then
              printfn "You aint got the facilities for that big man. Cunch is waiting for you (inside joke - Insufficient funds)."
          else
              this.Balance <- this.Balance - cash
              printfn "You have withdrawn £%f. Your balance is now: £%f." cash this.Balance
  
      member this.Deposit(cash : float) =
          this.Balance <- this.Balance + cash
          printfn "£%f Bag Secured. Your new Balance is: £%f" cash this.Balance
  
      member this.Print() = 
          printfn "Account Number: %s" this.AccountNumber
          printfn "Balance: £%.2f" this.Balance
  
  let CheckAccount (account : Account) =
      match account with
      | account when account.Balance < 10.0 -> printfn "Get your bread up"
      | account when account.Balance > 100.0 -> printfn "Balling out broski, keep hustling B)"
      | _ -> printfn "Rest when your dead, keep hustling!"
  
  let PrintSequence(s : seq<Account>) =
      for acc in s do acc.Print()
  
  [<EntryPoint>]
  let main argv =
      // Task 2
      let acc1 = new Account("Jeff", 72.0)
      let acc2 = new Account("Gigi", 27.0)
      let acc3 = new Account("Devonte", 7.0)
      let acc4 = new Account("YSL Day-Day", 27007200.0)
      let acc5 = new Account("Mover", 23.0)
      let acc6 = new Account("Teezy", 72.0)
      CheckAccount(acc1)
      CheckAccount(acc2)
      CheckAccount(acc3)
      CheckAccount(acc4)
      CheckAccount(acc5)
      CheckAccount(acc6)
  
      // Task 3
      let accounts : Account list = [ acc1; acc2; acc3; acc4; acc5; acc6 ]
      let seqBalLess50 =
          seq { for acc in accounts do if acc.Balance < 50.0 && acc.Balance >= 0.0 then acc }
  
      let seqBalGreater50 =
          seq { for acc in accounts do if acc.Balance >= 50.0 then acc }
  
      printfn ""
  
      printfn "---- Account has a Balance < 50 ----"
      PrintSequence(seqBalLess50)
  
      printfn ""
  
      printfn "---- Account has a Balance which is >= 50 ----"
      PrintSequence(seqBalGreater50)
      0