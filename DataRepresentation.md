
# Data Representation
## Number Systems
| | |
| :-: | :-: |
**Number Sets** <br> These are the various different classifications of numbers, such as real numbers (those without an imaginary element), integers (whole numbers), natural numbers (whole non-negative numbers)| **Denary Numbers** <br> Denary numbers are the standard way of writing numbers. Denary means it is written in base 10, as most mathematics is done. Common things such as 2 + 2 = 4 is true in denary. This is the most basic form taught in primary schools. | 
**Binary Numbers** <br> Binary numbers are written the same number as denary numbers, but in various exponents with base 2. This means that 01101010 is expressed as $$2^6+2^5+2^3+2^1 = 106$$ Binary numbers are used in computers. | **Hexadecimal Numbers** <br> Hexadecimal numbers, similarly to binary numbers, are the same as denary numbers, but expressed as various exponents with base 16. This means that 3209fd is expressed as $$3(16^5)+2(16^4) +9(16^2)$$ $$+15(16^1)+13(16^0) = 3279357$$ |

## Bits, Bytes & Binary
| | |
| :-: | :-: |
**ASCII** <br> ASCII is an 8-bit character encoding system which maps a key of an 8-bit binary string to a character. Since it has 8 bits, it can represent 2^8 different characters. | **Unicode** <br> Unicode is a larger character encoding system than ASCII, instead using 16 bits. This allows it to represent more characters ($2^{16}$ instead of $2^8$) than ASCII. |
**Transmission Errors** <br> Transmission errors are erroneous errors in bit strings caused by various issues (e.g. interruption). Their effect can be lessened by various checking mechanisms. | **Error Detection** <br> Error detection is the mechanisms which systems receiving data can check that it is correct. These include *parity bit*, *majority voting* & *checksums*
**Parity** <br> Parity bits are attached to the end of a binary string, and contain a bit which is needed to make the number of 1s in that whole string even: if the number of 1s in that string (including the parity bit) is not even, it is incorrect | **Majority Voting** <br> Majority voting is where a binary string is sent three times and for each index, the majority bit is chosen to be the one that is accepted.
