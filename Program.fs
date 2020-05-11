open System
open System.IO

let fileName = "Programming Challenge-CN-Data.txt"

let lines = File.ReadAllLines fileName

type AdjacentNode =
    { Id: int
      Neighbours: int list }

type BfsResult =
    { Id: int
      DistanceFromNode: int }

let graphOfQuestion =
    lines
    |> Array.map (fun x -> 
        let tokens = x.Split [|' '|]

        {
            Id = Int32.Parse tokens.[0]
            Neighbours = tokens.[2..] |> Array.map Int32.Parse |> List.ofSeq
        }
    )

let sampleGraph = [|
    { Id = 0; Neighbours = [1;2]}
    { Id = 1; Neighbours = [3;5]}
    { Id = 2; Neighbours = [1;3;4]}
    { Id = 3; Neighbours = []}
    { Id = 4; Neighbours = [6]}
    { Id = 5; Neighbours = [3]}
    { Id = 6; Neighbours = []}
|]

let findNode (graph:AdjacentNode[]) id = graph |> Array.find (fun x -> x.Id = id)

let bfs (startId:int) (graph:AdjacentNode[]) =
    let rec bfs queue visited results progress =
        match queue with
        | [] -> results
        | (v, depth)::others ->
            if progress % 1000. = 0. then printfn "Progress = %f" (progress / (float graph.Length) * 100.)
            let node = findNode graph v
            let nonVisited = node.Neighbours |> List.filter (fun x -> visited |> List.contains x |> not)
            let newVisited = visited @ nonVisited
            let newQueue = others @ (nonVisited |> List.map (fun x -> (x, depth + 1)))
            let result = {
                Id = v
                DistanceFromNode = depth
            }
            let newResults = result::results
            bfs newQueue newVisited newResults (progress + 1.)

    bfs [startId, 0] [0] [] 0.

let closeness (startId:int) graph =
    let distances = bfs startId graph
    let sum = distances |> List.sumBy (fun x -> x.DistanceFromNode) |> float

    sum / (distances.Length |> float)

[<EntryPoint>]
let main argv =
    printfn "Closeness centrlity: %A" (closeness 0 graphOfQuestion)
    0 // return an integer exit code
