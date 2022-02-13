namespace CSRakowski.AreThere.FsTests

open System
open System.Collections.Generic
open System.Linq
open CSRakowski.AreThere
open Xunit

module public Tests =

    [<Theory>]
    [<MemberData("GetData_Any")>]
    let ``ThereAre Any`` (elements: IEnumerable<'T>) (expected: bool) =
        let actual = ThereAre.Any elements
        Assert.Equal(expected, actual)


    [<Theory>]
    [<MemberData("GetData_Any")>]
    let ``ThereAre No`` (elements: IEnumerable<'T>) (expected: bool) =
        let actual = ThereAre.No elements
        Assert.NotEqual(expected, actual)


    [<Theory>]
    [<MemberData("GetData_Count")>]
    let ``ThereAre At Least`` (elements: IEnumerable<'T>) (numberOfElements: int) (expected: bool) =
        let actual = ThereAre.AtLeast numberOfElements elements
        Assert.Equal(expected, actual)


    [<Theory>]
    [<MemberData("GetData_Count")>]
    let ``ThereAre No More Than`` (elements: IEnumerable<'T>) (numberOfElements: int) (expected: bool) =
        let actual = ThereAre.NoMoreThan numberOfElements elements
        Assert.NotEqual(expected, actual)


    [<Theory>]
    [<MemberData("GetData_Even")>]
    let ``ThereAre Even Number Of Elements`` (elements: IEnumerable<'T>) (expected: bool) =
        let actual = ThereAre.EvenNumberOfElements elements
        Assert.Equal(expected, actual)


    [<Theory>]
    [<MemberData("GetData_Even")>]
    let ``ThereAre Odd Number Of Elements`` (elements: IEnumerable<'T>) (expected: bool) =
        let actual = ThereAre.OddNumberOfElements elements
        Assert.NotEqual(expected, actual)


    [<Theory>]
    [<MemberData("GetData_CountExact")>]
    let ``ThereAre Exactly`` (elements: IEnumerable<'T>) (numberOfElements: int) (expected: bool) =
        let actual = ThereAre.Exactly numberOfElements elements
        Assert.Equal(expected, actual)


    [<Theory>]
    [<MemberData("GetData_CountExact")>]
    let ``ThereAre HowMany`` (elements: IEnumerable<'T>) (expected: int) (isCorrect: bool) =
        let actual = ThereAre.HowMany elements
        if isCorrect then
            Assert.Equal(expected, actual)
        else
            Assert.NotEqual(expected, actual)


    let GetData_Any : seq<obj[]> =
        seq {
            yield [| Enumerable.Range(1, 10); true |]
            yield [| Enumerable.Empty<int>(); false |]
            yield [| [| 1; 2; 3 |]; true |]
            yield [| Array.Empty<int>(); false |]
            yield [| new List<int>(); false |]
        };

    let GetData_Count : seq<obj[]> =
        seq {
            yield [| Enumerable.Range(1, 10); 10; true |]
            yield [| Enumerable.Range(1, 10); 11; false |]
            yield [| Enumerable.Range(1, 10); 9; true |]
            yield [| Enumerable.Empty<int>(); 0; true |]
            yield [| [| 1; 2; 3 |]; 3; true |]
            yield [| Array.Empty<int>(); 0; true |]
            yield [| new List<int>(); 0; true |]
            yield [| Enumerable.Range(1, 10); 11; false |]
            yield [| Enumerable.Empty<int>(); 1; false |]
            yield [| [| 1; 2; 3 |]; 4; false |]
            yield [| Array.Empty<int>(); 1; false |]
            yield [| new List<int>(); 1; false |]
        };

    let GetData_Even : seq<obj[]> =
        seq {
            yield [| Enumerable.Range(1, 10); true |]
            yield [| Enumerable.Range(1, 4); true |]
            yield [| Enumerable.Range(1, 5); false |]
            yield [| Enumerable.Range(1, 9); false |]
            yield [| Enumerable.Empty<int>(); true |]
            yield [| [| 1; 2; 3 |]; false |]
            yield [| Array.Empty<int>(); true |]
            yield [| new List<int>(); true |]
        };

    let GetData_CountExact : seq<obj[]> =
        seq {
            yield [| Enumerable.Range(1, 10); 10; true |]
            yield [| Enumerable.Range(1, 10); 11; false |]
            yield [| Enumerable.Range(1, 10); 9; false |]
            yield [| Enumerable.Empty<int>(); 0; true |]
            yield [| [| 1; 2; 3 |]; 3; true |]
            yield [| Array.Empty<int>(); 0; true |]
            yield [| new List<int>(); 0; true |]
            yield [| Enumerable.Range(1, 10); 11; false |]
            yield [| Enumerable.Empty<int>(); 1; false |]
            yield [| [| 1; 2; 3 |]; 4; false |]
            yield [| Array.Empty<int>(); 1; false |]
            yield [| new List<int>(); 1; false |]
            yield [| [| 1 |]; 1; true |]
        };