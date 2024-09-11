import os.path

#Question-luokka käyttää questions-listassa listattuja olioita, joilla kaksi parametria: question_prompts-listan indeksin numero ja oikea vastaus
class Question:
  def __init__(self, prompt, answer):
    self.prompt = prompt
    self.answer = answer

#lista, joka sisältää visailun kysymykset
question_prompts = [
  "1. Kuinka monta aikavyöhykettä Venäjällä on?\n(a) 7\n(b) 11\n(c) 3\n\n",
  "2. Mikä on Japanin kansalliskukka? (\n(a) kirsikankukka\n(b) omenankukka \n(c) lootuskukka\n\n",
  "3. Mikä oli Istanbulin nimi ennen vuotta 1923?\n(a) Marmara\n(b) Galata \n(c) Konstantinopoli\n\n",
  "4. Kuinka monta raitaa Yhdysvaltain lipussa on?\n(a) 11\n(b) 15\n(c) 13\n\n",
  "5. Mikä on Australian kansalliseläin?\n(a) koala\n(b) punajättikenguru\n(c) kojootti\n\n",
  "6. Kuinka monessa päivässä Maa kiertää Auringon?\n(a) 360 \n(b) 364\n(c) 365\n\n",
  "7. Millä seuraavista imperiumeista ei ollut lainkaan kirjoitettua kieltä?\n(a) inkoilla\n(b) atsteekeilla\n(c) eqyptiläisillä\n(d) roomalaisilla\n\n",
  "8. Missä järjestettiin ensimmäiset modernin ajan olympialaiset?\n(a) Ateenassa\n(b) Roomassa\n(c) Pariisissa\n\n",
  "9. Mikä oli Disneyn ensimmäinen elokuva?\n(a) Pinokkio\n(b) Tuhkimo\n(c) Lumikki\n\n",
  "10. Minä vuonna Netflix perustettiin?\n(a) 1997\n(b) 2001\n(c) 2009\n(d) 2015\n\n",
  "11. Mitä tapahtui 20. heinäkuuta 1969?\n(a) Jethro Tull esiintyi Helsingin Kulttuuritalossa\n(b) Led Zeppelin julkaisi esikoisalbuminsa\n(c) Apollo 11 laskeutui Kuuhun\n\n",
  "12. Mistä kaupungista The Beatles on lähtöisin?\n(a) Lontoo\n(b) Liverpool\n(c) Manchester\n\n",
  "13. Millä slanginimellä paikalliset kutsuvat New York Cityä?\n(a) Gotham\n(b) Big Apple\n(c) Sin City\n\n",
  "14. Mikä on 2000-luvun myydyin kirjasarja?\n(a) Hunger Games\n(b) Twilight\n(c) Harry Potter\n\n",
  "15. Kuinka monta kosketinta pianossa on?\n(a) 75\n(b) 88\n(c) 90\n\n",
  "16. Minkä nimisessä kahvilassa Frendit-sarjan hahmot viettävät aikaansa?\n(a) Central Perk\n(b) Central Coffee\n(c) Perk Caffee\n\n",
  "17. Mitä jalkapallojoukkuetta kutsutaan nimellä The Red Devils?\n(a) FC Barcelona\n(b) Liverpool FC\n(c) Manchester United FC\n\n",
  "18. Millä valtiolla on eniten saaria?\n(a) Suomi\n(b) Kanada\n(c) Ruotsi\n\n",
  "19. Mikä on maailman pienin valtio?\n(a) Liechtenstein\n(b) Monaco\n(c) Vatikaani\n\n",
  "20. Minkä nimisestä maalauksesta norjalaistaiteilija Edvard Munch on kuuluisa?\n(a) Kuoleman puutarha\n(b) Huuto\n(c) Haavoittunut enkeli\n\n",
  "21. Missä kielessä on eniten sanoja (sanakirjoihin merkittyjen sanojen määrällä mitattuna)? \n(a) ranskan kielessä \n(b) englannin kielessä\n(c) suomen kielessä\n\n",
  "22. Mikä on Kanadan pääkaupunki?\n(a) Toronto\n(b) Motreal\n(c) Ottawa\n\n",
  "23. Mikä on maailman pisin joki?\n(a) Niili\n(b) Jangtse\n(c) Amazon\n\n",
  "24. Mikä oli Pixarin ensimmäinen kokoillan elokuva?\n(a) Toy Story\n(b) Ötökän elämää\n(c) Monsterit Oy\n\n",
  "25. Minä vuonna julkaistiin Voguen ensimmäinen numero?\n(a) 1892\n(b) 1920\n(c) 1961\n\n"
  ]

#lista jossa Question-luokan objektit, joilla kaksi parametria: question_prompts-listan indeksin numero ja oikea vastaus
questions = [
  Question(question_prompts[0], "b"),
  Question(question_prompts[1], "a"),
  Question(question_prompts[2], "c"),
  Question(question_prompts[3], "c"),
  Question(question_prompts[4], "b"),
  Question(question_prompts[5], "c"),
  Question(question_prompts[6], "a"),
  Question(question_prompts[7], "a"),
  Question(question_prompts[8], "c"),
  Question(question_prompts[9], "a"),
  Question(question_prompts[10], "c"),
  Question(question_prompts[11], "b"),
  Question(question_prompts[12], "a"),
  Question(question_prompts[13], "c"),
  Question(question_prompts[14], "b"),
  Question(question_prompts[15], "a"),
  Question(question_prompts[16], "c"),
  Question(question_prompts[17], "c"),
  Question(question_prompts[18], "c"),
  Question(question_prompts[19], "b"),
  Question(question_prompts[20], "b"),
  Question(question_prompts[21], "c"),
  Question(question_prompts[22], "a"),
  Question(question_prompts[23], "a"),
  Question(question_prompts[24], "a")
]

# tyhjä scores-lista, johon tallentuu qmachine-funktiosta pelaajan nimi ja saadut pisteet
scores = []

# funktio, joka kysyy käyttäjän nimen ja lisää sen listaan, sen jälkeen kysyy kysymyksen questions-listasta
# questions-listassa question classin olioita
# tarkistaa onko käyttäjän vastaus sama kuin question-classin oliolla ja lisää käyttäjälle pisteen mikäli vastaus oli oikea
# tulostaa pisteiden perusteella erilaisia kannustuksia pelaajalle

def qmachine():
  playername = input("Anna nimesi: ")
  scores.append(playername)
  score = 0
  for question in questions:
    answer = input(question.prompt)
    if answer == question.answer:
      score += 1
  if score == 0:
    print("Sait " + {str(score)} + "/" + str(len(questions)) + ", kysymystä oikein. Yritä nyt vähän! ")
  if 0 < score <= 20:
    print("Sait " + str(score) + "/" + str(len(questions)) + ", kysymystä oikein. Pystyt kyllä parempaan! ")
  if score > 20:
   print("Sait " + str(score) + "/" + str(len(questions)) + ", kysymystä oikein. Hyvää työtä!")
  scores.append(str(score))

qmachine()

#lopuksi scores-lista yhdistetään
scores = ', '.join(scores)

# tekee scoreboard-kansion aseman juureen mikäli sitä ei ole olemassa, jonne tallentaa pelaajan nimen ja tuloksen tulostauluun tiedostoon scoreboard.txt
# jos tulosta ei jostain syystä voi tallentaa, tulostaa virheilmoituksen
try:
  path = os.path.expanduser("~/scoreboard")
  if not os.path.exists(path): os.makedirs(path)
  path += "/"
  filename = "scoreboard.txt"
  file = open(path + filename, "a+")
  file.write(scores)
  file.write("\n")
  file.close()
  print("Tulos tallennettu tulostauluun!")
except:
  print("Tulosta ei tallennettu, jokin meni pieleen")
  




