# F# Closeness Centrality of graph using BFS

This is a sample F# source code that calculates closeness centrality of a graph using BFS

Two graph examples are provided in source code, one for `Programming Challenge-CN-Data.txt` which has 22963 nodes, called `graphOfQuestion`, and a simpler one with 6 nodes called `sampleGraph`

### Code Sample:
```fsharp
printfn "Closeness centrlity: %A" (closeness 0 graphOfQuestion)
(* Closeness centrlity: 2.710360145 *)
```

### Prerequesties

- .NET Core 3 (F# compiler and all tools are bundled with dotnet)

### Run
```powershell
cd challenge
dotnet run
```
