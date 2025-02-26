# CybersecurityEncryptions

## A simple ASP.NET MVC web app, my semester project for cybersecurity class at college
It utilizes Caesar, Polybius, Playfair, Vignere and RSA ciphers, some in their most basic form (changing J=>I, all caps, no diacritics, no whitespaces, and so on and so forth)

### Tech details <sub>(yeah... as if somebody was going to read that)</sub>

Since all of the algorythms (not including RSA) need a valid defined alphabet and a method to normalize strings (remove whitespaces, remove diacritics etc.), they all extend the AbstractCipher class which contains both
Also all of them implement ICipher, which, while not utilized in this one project, could be a solid base to build a more complex and sophisticated web app
For RSA, since it's a lot more complicated than the others, i used a library System.Security.Cryptography
Since the whole app is constructed in MVC architecture, all of the cipher classes are, of course, models.

