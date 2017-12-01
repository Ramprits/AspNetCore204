use SG_OpenTraining
Select Id,Name,[Description],AverageCost AS Cost , ConcernedPublic as comments From dbo.Training
WHERE IsActive = 1


Select * From dbo.TrainingCategory

