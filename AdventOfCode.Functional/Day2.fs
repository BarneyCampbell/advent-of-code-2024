namespace AdventOfCode.Functional

module D2 =
    let testDiff x y =
        let diff = Lib.difference x y
        diff >= 1 && diff <= 3

    let testDirection (x: int) (y: int) (increase: int) =
        increase = Lib.incOrDec x y

    // Two separate calls, one looking for increase and one for decrease.
    let rec worksWithRemoval' increase list =
        match list with
        | x::y::z::xs -> if testDiff x y && testDirection x y increase 
                            then (worksWithRemoval' increase (x::xs)) 
                            else worksWithRemoval' increase (x::z::xs) || worksWithRemoval' increase (y::z::xs)
        | x::y::[]    -> true
        | x::[]       -> true
        | _ -> false
    let rec worksWithRemoval'' list =
        match list with
        | x::y::z::xs -> if testDiff x y 
                            then worksWithRemoval'' (z::xs) 
                            else worksWithRemoval'' (x::z::xs) || worksWithRemoval'' (y::z::xs)
        | x::y::[]    -> true
        | x::[]       -> true
        | _ -> false

        // [ 7, 6, 4, 2, 1 ];
        // 7 6 4 [4, 2, 1] -- testdiff x y = 1 (true)

        // [1, 2, 7, 8, 9]
        // 1 2 7 [8, 9] -- testdiff 1 2 = 1 (true)

    let rec worksWithRemoval increase (list: int list) itemRemoved prev =
        printfn "%A removed an item: %b" list itemRemoved
        match list with
        | x::y::[] -> (testDirection x y increase && testDiff x y) || (not itemRemoved)
        | x::y::xs -> if testDirection x y increase
                        then testDiff x y && worksWithRemoval increase (y::xs) itemRemoved x
                        else
                            let wx = lazy worksWithRemoval increase (x::xs) true prev
                            let wy = lazy worksWithRemoval increase (y::xs) true prev
                            testDiff x y && not itemRemoved && ( (wx.Value && (testDirection x prev increase && testDiff x prev)) || (wy.Value && (testDirection x prev increase && testDiff x prev)) )
        | _ -> false


    let rec allIncOrAllDec' increase (list: int list) init =
        match list with
        | y::[] -> if increase
                    then init < y
                    else init > y
        | y::xs -> if increase
                    then init < y && allIncOrAllDec' increase xs y
                    else init > y && allIncOrAllDec' increase xs y
        | _ -> true


    let worksWithRemovalRunner (arr: int array) =
        let list = List.ofArray arr
        let inc = worksWithRemoval 1 list false -1
        printfn "-------> %b" inc
        let dec = worksWithRemoval -1 list false -1
        printfn "-------> %b" dec
        //printfn "%b || %b => %b" inc dec (inc || dec)
        //printf "%A %b\n" list ((worksWithRemoval 1 list false) || (worksWithRemoval -1 list false))
        //(worksWithRemoval 1 list false) || (worksWithRemoval -1 list false)

        inc || dec