namespace CSRakowski.AreThere

open System.Collections.Generic

module public ThereAre =
    let Any<'T> (collection: IEnumerable<'T>) =
        collection.GetEnumerator().MoveNext()

    let No<'T> (collection: IEnumerable<'T>) =
        collection.GetEnumerator().MoveNext() |> not

    let AtLeast<'T> (numberOfElements: int) (collection: IEnumerable<'T>) =
        let rec _atLeast (enumerator: IEnumerator<'T>) (currentCount: int) (numberOfElements: int) =
            if currentCount >= numberOfElements then
                true
            else
                if enumerator.MoveNext() then
                    _atLeast enumerator (currentCount + 1) numberOfElements
                else
                    false

        _atLeast (collection.GetEnumerator()) 0 numberOfElements


    let NoMoreThan<'T> (numberOfElements: int) (collection: IEnumerable<'T>) =
        let rec _noMoreThan (enumerator: IEnumerator<'T>) (currentCount: int) (numberOfElements: int) =
            if currentCount >= numberOfElements then
                false
            else
                if enumerator.MoveNext() then
                    _noMoreThan enumerator (currentCount + 1) numberOfElements
                else
                    true

        _noMoreThan (collection.GetEnumerator()) 0 numberOfElements

    let EvenNumberOfElements<'T> (collection: IEnumerable<'T>) =
        let rec _even (enumerator: IEnumerator<'T>) (currentCount: int) =
            if enumerator.MoveNext() |> not then
                currentCount % 2 = 0
            else
                _even enumerator (currentCount + 1)

        _even (collection.GetEnumerator()) 0

    let OddNumberOfElements<'T> (collection: IEnumerable<'T>) =
        let rec _odd (enumerator: IEnumerator<'T>) (currentCount: int) =
            if enumerator.MoveNext() |> not then
                currentCount % 2 <> 0
            else
                _odd enumerator (currentCount + 1)

        _odd (collection.GetEnumerator()) 0