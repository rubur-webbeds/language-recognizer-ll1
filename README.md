# language-recognizer-ll1
Recognize a LL(1) language class using a stack automaton


We'll be able to code an automaton that recognizes the lenguage described in the next table:

|    | Production | Variable | First        | Follow             | Select    | p  | f  | i  | s  | g  | m  | h  | # |
|----|------------|----------|--------------|--------------------|-----------|----|----|----|----|----|----|----|---|
| p0 | P -> pBf   | P        | {p}          | {#}                | {p}       | p0 |    |    |    |    |    |    |   |
| p1 | B -> IB    | B        | {i, s, m, λ} | {f, g, h}          | {i, s, m} |    |    | p1 | p1 |    | p1 |    |   |
| p2 | B -> λ     | B        | {i, s, m, λ} | {f, g, h}          | {f, g, h} |    | p2 |    |    | p2 |    | p2 |   |
| p3 | I -> i     | I        | {i, s, m}    | {i, s, m, f, g, h} | {i}       |    |    | p3 |    |    |    |    |   |
| p4 | I -> sBg   | I        | {i, s, m}    | {i, s, m, f, g, h} | {s}       |    |    |    | p4 |    |    |    |   |
| p5 | I -> mBh   | I        | {i, s, m}    | {i, s, m, f, g, h} | {m}       |    |    |    |    |    | p5 |    |   |
