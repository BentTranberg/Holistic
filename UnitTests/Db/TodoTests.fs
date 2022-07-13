module Db.TodoTests

open NUnit.Framework
open Swensen.Unquote
open Holistic.Business

[<Test>]
let ``Call EntToDo dot get``() =
    let result = EntTodo.get 1
    let expected: EntTodo option =
        Some { Id = 1; Title = "First"; Description = None }
    test <@ result = expected @>

    let result = EntTodo.get 2
    let expected: EntTodo option =
        Some { Id = 2; Title = "Second"; Description = Some "" }
    test <@ result = expected @>

    let result = EntTodo.get 3
    let expected: EntTodo option =
        Some { Id = 3; Title = "Third"; Description = Some "This is the third issue." }
    test <@ result = expected @>

    let result = EntTodo.get 4
    let expected: EntTodo option = None
    test <@ result = expected @>
