# Sqrt

Square root, stable and fast algorithm. Halley's method: plans the next step using the derivative evaluated midway between the current and next positions.

$x_n=x_p-\frac{2 x_p \left({x^2_p}-S\right)}{S+3 {x^2_p}}=x_p-\frac{2 x_p\left({x^2_p}-S\right)}{4\ S+3( {x^2_p}-S)}=\frac{2 x_p\cdot s}{4\cdot S+3\cdot s},\quad s ={x^2_p}-S$

```wolfram
(*=====Wolfram Language=====*)

(* Newton-Raphson step *)
xn == xp - (xp^2 - S)/(2 xp);

(* Halley's step as a nested correction *)
xn == xp - (xp^2 - S)/(2 * (xp - (xp^2 - S)/(4 * xp)));
FullSimplify[(xp^2 - S)/(2 * (xp - (xp^2 - S)/(4 * xp)))]
```

Performance & Stability

While this sqrt algorithm is stable, maintaining ultimate precision across exceptionally large numbers naturally consumes more processor cycles. By leveraging the floating-point representation—specifically normalising the exponent—we can drastically reduce the search space. This optimisation ensures guaranteed convergence within just 5 to 6 iterations across the entire IEEE 754 double precision range.

Note on cubic convergence and stability:

```wolfram
(* Halley's method as a midpoint derivative evaluation *)
Solve[(xn - xp) == -(xp^2 - S) / (2 * ((xn + xp) / 2)), xn]

(* Output: {{xn -> -Sqrt[S]}, {xn -> Sqrt[S]}} *)
```

Geometrically, the underlying parabola is traversed in exactly one step when using the true midpoint derivative. In practice, substituting $x_n$​ with a preliminary Newton step lowers the pure theoretical convergence, yet it ensures algorithmic stability. This safeguard prevents the engine from overstepping the solution; in the vicinity of zero, the method transitions smoothly into a bisectional regime, guaranteeing convergence under all conditions.
