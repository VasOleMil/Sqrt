# Sqrt

Square root, stable and fast algorithm. Halley's method: plans the next step using the derivative evaluated midway between the current and next positions.

$x_n=x_p-\frac{2 x_p \left({x_p}^2-S\right)}{S+3 {x_p}^2}=x_p-\frac{2 x_p\left({x_p}^2-S\right)}{4\ S+3( {x_p}^2-S)}$

```wolfram
(* Newton-Raphson step *)
xn == xp - (xp^2 - S)/(2 xp);

(* Halley's step as a nested correction *)
xn == xp - (xp^2 - S)/(2 * (xp - (xp^2 - S)/(4 * xp)));
FullSimplify[(xp^2 - S)/(2 * (xp - (xp^2 - S)/(4 * xp)))]
```

Performance & Stability

While this sqrt algorithm is perfectly stable, maintaining ultimate precision across exceptionally large numbers naturally consumes more processor cycles. By leveraging the floating-point representation—specifically normalising the exponent—we can drastically reduce the search space. This optimisation ensures guaranteed convergence within just 5 to 6 iterations across the entire IEEE 754 double precision range.

Note on cubic convergence and stability:

```wolfram
(* Halley's method as a midpoint derivative evaluation *)
Solve[(xn - xp) == -(xp^2 - S) / (2 * (xn + xp) / 2), xn]

(* Output: {{xn -> -Sqrt[S]}, {xn -> Sqrt[S]}} *)
```
Geometrically, the underlying parabola is traversed in exactly one step when using the true midpoint derivative. In practice, substituting $x_n$​ with a preliminary Newton step slightly lowers the pure theoretical convergence, but it guarantees algorithmic stability and ensures the engine never oversteps the true solution.
