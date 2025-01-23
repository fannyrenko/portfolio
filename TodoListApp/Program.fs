open System
open System.IO

// Tehtävän prioriteetti
type Priority = Low | Medium | High

// Tietorakenne yksittäiselle tehtävälle
type ToDoItem = { Id: int; Description: string; IsDone: bool; Priority: Priority }

// Tehtävälista
let mutable todoList: ToDoItem list = []

// Tiedostonimi, johon tehtävät tallennetaan
let todoListFile = "todoList.txt"

// Funktio joka lataa tehtävät tiedostosta
let loadFromFile (filename: string) =
    if File.Exists(filename) then
        let lines = File.ReadAllLines(filename)
        lines
        |> Array.toList
        |> List.map (fun line ->
            let parts = line.Split(',')
            let isDone = 
                match Boolean.TryParse(parts.[2]) with
                | true, value -> value
                | _ -> false 
            let priority = 
                match parts.[3] with
                | "1" -> Low
                | "2" -> Medium
                | "3" -> High
                | _ -> Low  // Oletusarvo, jos ei ole kelvollinen valinta
            { Id = int parts.[0]; Description = parts.[1]; IsDone = isDone; Priority = priority })
    else
        printfn "Tiedostoa ei löytynyt. Aloitetaan tyhjällä listalla."
        []  // Palautetaan tyhjä lista, jos tiedostoa ei löydy

// Funktio joka tallentaa tehtävät tiedostoon
let saveToFile (filename: string) =
    let lines = 
        todoList
        |> List.map (fun t -> sprintf "%d,%s,%b,%d" t.Id t.Description t.IsDone (match t.Priority with Low -> 1 | Medium -> 2 | High -> 3))  
    File.WriteAllLines(filename, lines)
    printfn "Tehtävät tallennettu tiedostoon."

// Valikko
let showMenu () =
    printfn "\n== Todo List Menu =="
    printfn "1. Näytä tehtävät"
    printfn "2. Lisää tehtävä"
    printfn "3. Poista tehtävä"
    printfn "4. Merkitse tehtävä tehdyksi"
    printfn "5. Näytä tehdyt tehtävät"
    printfn "6. Näytä tekemättömät tehtävät"
    printfn "7. Poistu ohjelmasta\n"

// Näytä tehtävät, lajiteltuna prioriteetin mukaan
let showTodos () =
    if List.isEmpty todoList then
        printfn "Ei tehtäviä"
    else 
        printfn "\n== Tehtävät =="
        todoList
        |> List.sortBy (fun t -> 
            match t.Priority with
            | Low -> 1
            | Medium -> 2
            | High -> 3)
        |> List.iter (fun t ->
            let status = if t.IsDone then "[X]" else "[ ]"
            let priority = 
                match t.Priority with
                | Low -> "Matala"
                | Medium -> "Keskitaso"
                | High -> "Korkea"
            printfn "%d. %s %s - Prioriteetti: %s" t.Id status t.Description priority)

// Näytä vain tekemättömät tehtävät, lajiteltuna prioriteetin mukaan
let showUndoneTodos () =
    let undoneTodos = todoList |> List.filter (fun t -> not t.IsDone)
    if List.isEmpty undoneTodos then
        printfn "Ei tekemättömiä tehtäviä"
    else 
        printfn "\n== Tekemättömät tehtävät =="
        undoneTodos
        |> List.sortBy (fun t -> 
            match t.Priority with
            | Low -> 1
            | Medium -> 2
            | High -> 3)
        |> List.iter (fun t ->
            let priority = 
                match t.Priority with
                | Low -> "Matala"
                | Medium -> "Keskitaso"
                | High -> "Korkea"
            printfn "%d. %s - Prioriteetti: %s" t.Id t.Description priority)

// Näytä vain tehdyt tehtävät
let showDoneTodos () =
    let doneTodos = todoList |> List.filter (fun t -> t.IsDone)
    if List.isEmpty doneTodos then
        printfn "Ei tehtyjä tehtäviä"
    else 
        printfn "\n== Tehdyt tehtävät =="
        doneTodos
        |> List.iter (fun t ->
            let priority = 
                match t.Priority with
                | Low -> "Matala"
                | Medium -> "Keskitaso"
                | High -> "Korkea"
            printfn "%d. %s - Prioriteetti: %s" t.Id t.Description priority)

// Lisää tehtävä, prioriteetti kysytään
let addTodo () =
    printf "Syötä tehtävän kuvaus: "
    let description = Console.ReadLine()
    
    printf "Valitse prioriteetti (1 = Matala, 2 = Keskitaso, 3 = Korkea): "
    let priority = 
        match Console.ReadLine() with
        | "1" -> Low
        | "2" -> Medium
        | "3" -> High
        | _ -> Low  // Oletusarvo
    
    let newId = if List.isEmpty todoList then 1 else (List.maxBy (fun t -> t.Id) todoList).Id + 1
    let newItem = { Id = newId; Description = description; IsDone = false; Priority = priority }
    todoList <- newItem :: todoList
    printfn "Tehtävä lisätty"

// Poista tehtävä
let removeTodo () =
    printf "Syötä poistettavan tehtävän ID: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, id ->
        if List.exists ( fun t -> t.Id = id) todoList then
            todoList <- List.filter (fun t -> t.Id <> id) todoList
            printfn "Tehtävä poistettu"
        else   
            printfn "ID:tä ei löytynyt"
    | _ -> printfn "Virheellinen ID"

// Merkitse tehtävä tehdyksi
let markTodoDone () =
    printf "Syötä merkittävän tehtävän ID: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, id ->
        if List.exists (fun t -> t.Id = id) todoList then
            todoList <-
                todoList
                |> List.map (fun t -> if t.Id = id then { t with IsDone = true } else t)
            printfn "Tehtävä merkitty tehdyksi!"
        else
            printfn "ID ei löytynyt."
    | _ -> printfn "Virheellinen ID."

// Pääohjelman silmukka
let rec mainLoop () =
    showMenu ()
    printf "Valinta: "
    match Console.ReadLine() with
    | "1" -> showTodos (); mainLoop ()      // Näytä tehtävät
    | "2" -> addTodo (); mainLoop ()        // Lisää tehtävä
    | "3" -> removeTodo (); mainLoop ()     // Poista tehtävä
    | "4" -> markTodoDone (); mainLoop ()   // Merkitse tehtävä tehdyksi
    | "5" -> showDoneTodos(); mainLoop ()   // Näytä tehdyt tehtävät
    | "6" -> showUndoneTodos(); mainLoop () // Näytä tekemättömät tehtävät
    | "7" -> 
        saveToFile todoListFile  // Tallennetaan tehtävät ennen ohjelman sulkemista
        printfn "Suljetaan ohjelma. Heippa!" // Poistu ohjelmasta
    | _ -> printfn "Virheellinen valinta."; mainLoop () // Virheellinen valinta

// Ohjelman aloitus
[<EntryPoint>]
let main _ =
    printfn "Tervetuloa Todo-listaohjelmaan!"
    todoList <- loadFromFile todoListFile  // Ladataan tehtävät tiedostosta
    mainLoop ()
    0
