# CSharp Documentations
Repo To Keep Things to Learn, Resources and Code Samples Related to C#

## Coding Standards
- General
    - Read me file should be for developer use to understand the project
    - Docs folder should contain documentations related to project for client use
- Visual studio
    - Use new version of solution file `*.slnx`
    - Treat warnings as errors
    - Use nullable reference types
    - Use file scoped namespaces when it makes sense specially for CAD Projects
    - Use namespace without braces when possible to reduce indentation
    - Use Code analyser(Roslyn) to improve code quality, Try You can few more analyzer later
- Testing
    - Use xUnit for unit testing for all internal projects if it makes sense

### Language Version Support Table

| Framework          | C# Version |
|--------------------|------------|
| .Net framework 4.8 | 7.3 (You can also use 8.0 with some limitations)        |
| .Net Standard 2.0  | 7.3 (You can also use 8.0 with some limitations)        |
| .Net 8.0           | 12.0       |
| .Net 10            | 14.0       |
