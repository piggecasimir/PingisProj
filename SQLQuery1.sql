--select p1.[Name], Player1Sets, Player2Sets, p2.[Name] from Matches
--join Players p1 on p1.Id = Player1
--join Players p2 on p2.Id = Player2

update Players
set MatchesPlayed += 1, MatchesWon += @Player1Won, MatchesLost += @Player1Lost, SetsWon += @Player1Sets, SetsLost += @Player2Sets, SetDifference += @SetDiff
where Id = @Player1