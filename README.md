# Succession
The king in Utopia has died without an heir. Now several nobles in the country claim the throne. The country law states that if the ruler has no heir, the person who is most related to the founder of the country should rule.

To determine who is most related we measure the amount of blood in the veins of a claimant that comes from the founder. A person gets half the blood from the father and the other half from the mother. A child to the founder would have 1/2 royal blood, that child’s child with another parent who is not of royal lineage would have 1/4 royal blood, and so on. The person with the most blood from the founder is the one most related.

## Input
The first line contains two integers, N (2 - 50) and  M(2 - 50). The second line contains the name of the founder of Utopia.

Then follows N lines describing a family relation. Each such line contains three names, separated with a single space. The first name is a child and the remaining two names are the parents of the child.

Then follows N lines containing the names of those who claim the throne.

All names in the input will be between 1 and 10 characters long and only contain the lowercase English letters ‘a’–‘z’. The founder will not appear among the claimants, nor be described as a child to someone else.

## Output
A single line containing the name of the claimant with most blood from the founder. The input will be constructed so that the answer is unique.

The family relations may not be realistic when considering sex, age etc. However, every child will have two unique parents and no one will be a descendent from themselves. No one will be listed as a child twice.