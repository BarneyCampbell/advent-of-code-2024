namespace AdventOfCode.Functional

module Lib =
    let difference (x1: int) (x2: int): int = abs (x1 - x2)
    let incOrDec (x1: int) (x2: int): int = if (x1 = x2) then 0 else (x1 - x2) / difference x1 x2