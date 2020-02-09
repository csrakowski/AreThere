namespace CSRakowski.AreThere

open System.Collections.Generic

module public ThereAre =
    let Any<'T> (collection: IEnumerable<'T>): bool =
        collection.GetEnumerator().MoveNext()

    let No<'T> (collection: IEnumerable<'T>): bool =
        collection.GetEnumerator().MoveNext() |> not

    let AtLeast<'T> (numberOfElement: int) (collection: IEnumerable<'T>): bool =
        let mutable counted = 0;

        let enum = collection.GetEnumerator()

        let mutable continueLooping = true
        while continueLooping do
            if enum.MoveNext() |> not then
                continueLooping <- false
            else
                counted <- counted + 1
                if (counted >= numberOfElement) then
                   continueLooping <- false

        counted >= numberOfElement