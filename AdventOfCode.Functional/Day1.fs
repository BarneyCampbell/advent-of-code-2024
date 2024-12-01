namespace AdventOfCode.Functional

module D1 =
    let test = "abcde"
    let splitStr (s: string): int * int =
        let nums = s.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
        match List.ofArray nums with
        | (x::y::[])    -> (int x, int y)
        | _             -> (0, 0)

    let rec getNumListsFn (lines: string list) (acc1: int list) (acc2: int list): int list * int list =
        match lines with
        | (x::xs)   -> let (n1, n2) = splitStr x
                        in getNumListsFn xs (n1 :: acc1) (n2 :: acc2)
        | _         -> (acc1, acc2)

    let getNumLists (lines: string[]) =
        let (l1, l2) = getNumListsFn (List.ofArray lines) [] []
        (ResizeArray<int> l1, ResizeArray<int> l2)