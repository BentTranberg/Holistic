module Misc.FirstTests

open NUnit.Framework
open Swensen.Unquote

[<Test>]
let ``The first test``() =
    let expected = 7
    let result = 3
    test <@ result = expected @>

[<Test>]
let ``The second test``() =
    let expected = 9
    let result = 9
    test <@ result = expected @>
