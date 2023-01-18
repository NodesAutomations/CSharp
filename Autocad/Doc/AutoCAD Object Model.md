### AutoCAD Object Model As per my personal Understanding
```mermaid
graph TD
A[ACAD Application]-->B[Document Manager]
B-->C[Active Document]
C-->|All data in sepearate tables|D[DataBase]
C-->E[Editor]
D-->|Contain all Entities|F[BLock Table]
D-->G[Layer Table]
D-->H[DimStyle Table]
```
