namespace WordCounter.FSharp

open System
open WordCounter.Common

type FSharpWordCounter() =
    interface IWordCounter with
        member this.CountAndSortWords(input: string) =
            input.Split(null) |>
            Seq.filter(fun s -> not <| String.IsNullOrWhiteSpace s) |>
            Seq.groupBy(id) |>
            Seq.map(fun (key, seq) -> new WordCount(key, Seq.length seq)) |>
            Seq.sortBy(fun w -> w.Word) |>
            Seq.sortByDescending(fun w -> w.Count)
