# Pipeline Design Pattern

## Overview
- Pipeline is a behavioral design pattern that allows you to process a series of data through a sequence of processing stages, where each stage can modify the data or make decisions based on it.
- You can think of it as a series of steps that data goes through, where each step can transform the data or make decisions based on it.

## Use Case
- When you have a series of processing steps that need to be applied to data, and you want to decouple the steps from each other.
- When you want to be able to easily add, remove, or reorder processing steps without affecting the rest of the system.

## Code
- Assume we are building loan management system. 
- We have a loan application that needs to go through multiple stages of processing before it can be approved or rejected. 
- Each stage of processing can be represented as a separate component in the pipeline.


```csharp
//Class to store loan application details
public class LoanApplication
{
    public int Id { get; set; }
    public int Age { get; set; }
    public decimal Income { get; set; }
    public decimal LoanAmount { get; set; }
    public string Country { get; set; }

}
//Class to store the decision of the loan application
public class LoadDecision
{
    public int ApplicantId { get; set; }
    public bool IsApproved { get; set; }
    public string RejectionReason { get; set; }

    public override string ToString()
    {
        return $"ApplicantId: {ApplicantId}, IsApproved: {IsApproved}, RejectionReason: {RejectionReason}";
    }
}
```
```csharp
//Class to store the context of the loan application processing
public sealed class EligibilityContext
{
    public  LoanApplication LoanApplication { get; set; }
    public List<string> Warning { get; set; } = new List<string>();
    public bool IsRejected { get; set; }

    public string RejectionReason { get; set; }
    public void Reject(string reason)
    {
        IsRejected = true;
        RejectionReason = reason;
    }
    public void Warn(string reason)
    {
        Warning.Add(reason);
    }
}
```
```csharp
//Interface for the eligibility rules
public interface IEligibilityRule
{
    int Order { get; }
    void Evaluate(EligibilityContext context);
}
public sealed class AgeRule : IEligibilityRule
{
    public int Order => 1;
    public void Evaluate(EligibilityContext context)
    {
        if (context.LoanApplication.Age < 18)
        {
            context.Reject("Applicant must be at least 18 years old.");
        }
    }
}
public sealed class IncomeRule : IEligibilityRule
{
    public int Order => 2;
    public void Evaluate(EligibilityContext context)
    {
        if (context.LoanApplication.Income < 20000)
        {
            context.Reject("Applicant must have an income of at least $20,000.");
        }
    }
}

public sealed class LoanAmountRule : IEligibilityRule
{
    public int Order => 3;
    public void Evaluate(EligibilityContext context)
    {
        if (context.LoanApplication.LoanAmount > context.LoanApplication.Income * 5)
        {
            context.Reject("Loan amount cannot exceed 5 times the applicant's income.");
        }
    }
}

public sealed class CountryRule : IEligibilityRule
{
    public int Order => 4;
    private readonly HashSet<string> _allowedCountries = new HashSet<string> { "USA", "Canada", "UK" };
    public void Evaluate(EligibilityContext context)
    {
        if (!_allowedCountries.Contains(context.LoanApplication.Country))
        {
            context.Reject($"Applicants from {context.LoanApplication.Country} are not eligible.");
        }
    }
}
```
```csharp
public sealed class EligibilityPipeline
{
    private readonly List<IEligibilityRule> _rules;
    public EligibilityPipeline(List<IEligibilityRule> rules)
    {
        _rules = rules.OrderBy(r => r.Order).ToList();
    }

    public LoadDecision Run(LoanApplication loanApplication)
    {
        var context = new EligibilityContext { LoanApplication = loanApplication };
        foreach (var rule in _rules)
        {
            rule.Evaluate(context);
            if (context.IsRejected)
            {
                return new LoadDecision
                {
                    ApplicantId = loanApplication.Id, 
                    IsApproved = false,
                    RejectionReason = context.RejectionReason
                };
            }
        }

        return new LoadDecision
        {
            ApplicantId = loanApplication.Id,
            IsApproved = true,
            RejectionReason = "None"
        };
    }
}
```
```csharp
//Client Code
var loanApplications = new List<LoanApplication>
{
    new LoanApplication { Id = 1, Age = 25, Income = 30000, LoanAmount = 100000, Country = "USA" },
    new LoanApplication { Id = 2, Age = 17, Income = 15000, LoanAmount = 50000, Country = "Canada" },
    new LoanApplication { Id = 3, Age = 30, Income = 40000, LoanAmount = 250000, Country = "UK" }
}; 

//Pipeline setup
var rules = new List<IEligibilityRule>
{
    new AgeRule(),
    new IncomeRule(),
    new LoanAmountRule(),
    new CountryRule()
};

var pipeline = new EligibilityPipeline(rules);

foreach (var loanApplication in loanApplications)
{
    var decision = pipeline.Run(loanApplication);
    Console.WriteLine(decision);
}
```