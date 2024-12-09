# Osa 4 - Syväoppiminen harjoitustyö (15 p)

## Tekijä

- Fanny Renko, AB3835

## Aiheen kuvaus lyhyesti

Tässä projektissa tarkastellaan syväoppimisen käyttöä tekstiluokittelussa. Tavoitteena on kehittää malli, joka kykenee luokittelemaan erilaisia tekstityyppejä, kuten Amazon- ja IMDb-arvosteluja sekä sosiaalisen median viestejä. Käytän erilaisia syväoppimismalleja, kuten LSTM:ää, sekä perinteisiä koneoppimismenetelmiä, kuten Random Forestia, analysoidakseni ja verratakseni mallien suorituskykyä.

## Millä teknologioilla toteutus tehdään
- **Ohjelmointikieli**: Python
- **Koneoppimiskirjastot**: Scikit-learn (Random Forest), TensorFlow/Keras (LSTM)
- **Datan käsittely**: Pandas, NumPy
- **Visualisointi**: Matplotlib, Seaborn


## Tehtävä 4-1
### Aihe: Syväoppimisen toteutussuunnitelma + aineiston valinta (3 p)


### Datalähteet: 

### Kaggle-datasetit

 - Twitter-viestit: Twitter Sentiment Analysis
https://www.kaggle.com/datasets/jp797498e/twitter-entity-sentiment-analysis

 - Elokuva-arvostelut: IMDB Dataset of 50K Movie Reviews
https://www.kaggle.com/datasets/harshitshankhdhar/imdb-dataset-of-top-1000-movies-and-tv-shows

- SMS-viestit: Dataset of SMS messages
https://www.kaggle.com/datasets/leoarruda/documents

- Amazon tuotearvostelu: Amazon reviews
https://www.kaggle.com/datasets/kritanjalijain/amazon-reviews


## Tehtävä 4-2
### Aihe: Syväoppimisen toteutus (8 p)

**Valitut mallit**: LTSM-malli tekstintunnistukseen, Random Forrest-koneoppimismalli datan riittävyyden tarkistukseen

### Algoritmin toteutus

#### 1. Kirjastojen tuonti

Aloitin importoimalla tarvittavat Python-kirjastot, jotka ovat välttämättömiä datan käsittelyyn ja neuroverkon rakentamiseen. Käytin Pandas-kirjastoa datan käsittelyyn, NumPy-kirjastoa numeeristen laskelmien suorittamiseen, sekä Scikit-learn- ja Keras-kirjastoja koneoppimisen ja syväoppimisen työkalujen saamiseksi.

#### 2. Datan Tuonti

Latasin useista eri lähteistä kerätyt tekstidatat. Käytin pd.read_csv() -funktiota lukeakseni CSV-tiedostoja ja valitsin vain tarvittavat sarakkeet. Nimesin jokaisen datan sarakkeet samaan muotoon, jotta voin yhdistää ne myöhemmin.

#### 3. Etiketöinti ja yhdistäminen

Lisäsin jokaiselle DataFrame
label-sarakkeen, joka auttoi erottamaan eri tietolähteet. Amazon-arvosteluille annoin label 1, IMDb-arvosteluille label 2, Twitter-viesteille label 3 ja SMS-viesteille label 4. 

Varmistin, että jokaisessa lähteessä on sama määrä rivejä leikkaamalla kaikki DataFrame
pienimmän datan mukaan. Yhdistin lopuksi kaikki DataFramet
yhdeksi suureksi DataFrameksi, jossa on kaikki tekstit ja niiden etiketit.

#### 4. Tekstin esikäsittely

Ennen kuin pystyin syöttämään dataa neuroverkolle, esikäsittelin tekstit. Määrittelin sanaston koon ja maksimi pituuden teksteille. Käytin Tokenizer-luokkaa muuntamaan tekstit numeerisiksi sekvensseiksi ja pad_sequences-toimintoa varmistuakseni, että kaikki syötteet ovat saman pituisia (lisään nollia lyhyempiin sekvensseihin). Muutin etiketit niin, että ne alkavat nollasta.

#### 5. Datan jakaminen

Jaoin datan koulutus- ja testijoukkoihin train_test_split-toiminnolla, 80% datasta koulutukseen ja 20% testaukseen.

#### 6. Mallin rakentaminen

Rakensin LSTM-pohjaisen neuroverkon, joka sisältää useita kerroksia. Käytin Embedding-kerrosta muuntamaan sanasekvenssit tiheiksi vektoreiksi. Lisäsin kaksi LSTM-kerrosta, joiden jälkeen tulevat dropout-kerrokset ylikoulutuksen estämiseksi. Viimeisissä kerroksissa käytin tiheitä kerroksia, joissa on softmax-aktiivisuustoiminto, jotta voin ennustaa neljän eri luokan todennäköisyyksiä. Mallin käänsin käyttämällä sparse_categorical_crossentropy-häviötä ja Adam-optimointialgoritmia.

#### 7. Mallin koulutus

Mallin koulutuksessa käytin fit-metodia. Koulutin mallia enintään kuusi epookkia käyttäen erikokoisia tietojoukkoja ja lisäsin varhaisen lopetuksen mekanismin estääkseni ylikoulutuksen. Tämä tapahtui seuraamalla validointihäviötä ja pysäyttämällä koulutuksen, jos se ei parane usean ajon aikana.

#### 8. Ennustaminen ja arviointi

Kun malli oli koulutettu, pystyin ennustamaan testijoukon luokat käyttämällä predict-metodia. Ennustin luokat ja laskin niiden tarkkuuden vertaamalla ennustettuja luokkia todellisiin etiketteihin. Tuloksena sain mallin tarkkuuden, joka kertoo, kuinka hyvin malli suoriutui testidatasta.


## Tehtävä 4-3
### Aihe: Tulosten analysointi (4 p)

#### LTSM-mallin suorituskyky:
| Luokka | Precision | Recall | F1-Score | Support |
|--------|-----------|--------|----------|---------|
| 0      | 0.98      | 0.98   | 0.98     | 1129    |
| 1      | 0.99      | 0.99   | 0.99     | 1138    |
| 2      | 0.82      | 0.88   | 0.85     | 1103    |
| 3      | 0.86      | 0.80   | 0.83     | 1089    |
| **Accuracy** |       |        | **0.91** | **4459**  |
| **Macro Avg** | 0.91  | 0.91  | 0.91     | 4459    |
| **Weighted Avg** | 0.92 | 0.91  | 0.91     | 4459    |


### 1. Analysoi ja vertaile malleilla saamiasi oppimistuloksia

Aluksi hyödynsin Random Forest -menetelmää datan erottelukyvyn arviointiin. Random Forest saavutti 86,8 % tarkkuuden, mikä osoittaa, että luokkien erot ovat riittäviä luotettavaa luokittelua varten. Tämä tulos vahvisti, että datasetti soveltuu hyvin moniluokkaluokittelutehtävään.

LSTM-mallilla tarkkuus nousi 91 % testijoukossa, ja malli saavutti erinomaisen tarkkuuden erityisesti luokille 0 ja 1 (Amazon- ja IMDb-arvostelut). Näiden luokkien precision- ja recall-arvot olivat korkeat, mikä kertoo mallin vahvasta suorituskyvystä ja kyvystä tunnistaa niiden piirteet johdonmukaisesti. LSTM
sekventiaalinen rakenne auttaa hahmottamaan tekstien rakenteita, mikä hyödyttää erityisesti pidempiä, selkeämmin rakenteellisia tekstityyppejä, kuten arvosteluja.

Sen sijaan luokat 2 ja 3 (Twitter- ja SMS-viestit) osoittautuivat haastavammiksi, ja niiden F1-pisteet jäivät hieman alhaisemmiksi (0.85 ja 0.83). Tämä todennäköisesti johtuu näiden tekstien erityispiirteistä: ne ovat usein lyhyitä, epämuodollisia ja voivat sisältää slangia tai vaihtelevaa kielioppia. Tämä monimutkaisuus heikentää mallin kykyä tunnistaa piirteet yhtä tarkasti kuin muodollisemmissa teksteissä.

### 2. Kuinka syväoppiminen eri menetelmillä sujui valitun aineiston ja valittujen menetelmien

LSTM-malli soveltui hyvin tekstiluokittelutehtävään ja saavutti korkean tarkkuuden erityisesti pidemmissä teksteissä. Koulutusvaiheessa käyttämäni optimointikeinot, kuten early stopping ja ReduceLROnPlateau, estivät mallin ylikoulutusta ja paransivat sen kykyä yleistää. Dropout-kerrokset ja L2-regularisaatio osoittautuivat erityisen hyödyllisiksi, sillä alkuvaiheessa malli ei meinannut päästä yli 80 % tarkkuuteen ilman näitä säätöjä.


### 3. Kuinka hyvin menetelmä tai menetelmät toimi?

Kaiken kaikkiaan menetelmä toimi erittäin hyvin, saavuttaen 91 % tarkkuuden ja hyvät f1-pisteet, mikä osoittaa mallin kykenevän luotettavaan tekstiluokitteluun. LSTM toimii varsin hyvin yleiskäyttöisenä luokittelijana, mutta sen suorituskyky jäi hieman alhaisemmaksi haastavammissa luokissa, erityisesti lyhyissä ja epämuodollisissa tekstityypeissä. Näiden luokkien suorituskykyä olisi mahdollista parantaa esimerkiksi lisäkäsittelyillä tai muilla malliratkaisuilla.


### 4. Mitä kehitettävää syväoppimismallissa tai esikäsittelyvaiheessa havaitset? 
   
   * **Tekstin esikäsittely:** Tähän voisi sisällyttää slangin tunnistamista, erityisesti epämuodollisten tekstien kohdalla. Tämä voisi parantaa mallin suorituskykyä Twitter- ja SMS-viesteissä.

   * **Laajennettu sanasto:** Mallin sanastoa voisi laajentaa kattamaan lyhenteitä ja slangia. Tämä voisi olla hyödyllistä erityisesti sosiaalisen median tekstien ja lyhyiden viestien luokittelussa.

   * **Erilaisten syväoppimismallien kokeilu:** Joihinkin tekstityyppeihin voisi soveltaa muunnelmia, kuten CNN-LSTM-mallia, joka voisi parantaa mallin kykyä hahmottaa myös lyhyitä tai epämuodollisia tekstejä.


### 5. Kuinka voisit optimoida syväoppimismallia?

   * Lisäepochit ja early stopping -rajojen säätö: Voisi auttaa mallia oppimaan vielä pidemmälle ilman ylikoulutuksen riskiä.

   * Hyperparametrien optimointi esim. kokeilemalla erilaisia oppimisnopeuksia, dropout-arvoja ja LSTM-kerrosten määrää.

   * Lisäkoulutusaineisto, mallin tarkkuutta voisi parantaa myös lisäämällä datasettiin enemmän lyhyitä ja epämuodollisia tekstejä tai käyttämällä valmiiksi koulutettuja kielimalleja, kuten BERT tai GPT, jotka voivat auttaa tekstien piirteiden tehokkaammassa tunnistamisessa.  

### 6. Muita huomioita tehtävästä?

Datan monipuolisuus teki tästä luokittelutehtävästä sekä kiinnostavan että haastavan. Amazon- ja IMDb-arvostelut oli helppo luokitella, mutta lyhyet ja epämuodollisemmat viestit toivat omat haasteensa. Kaiken kaikkiaan syväoppiminen toimi hyvin tällaisessa tekstianalyysissä, mutta lopputulosta voisi vielä parantaa säätämällä mallia ja hyödyntämällä optimointikeinoja. Tämä projekti toi hyvin esiin sen, kuinka tärkeää esikäsittely on erityisesti silloin, kun käsitellään erilaisia tekstityyppejä – kuten lyhenteitä ja slangia sisältäviä viestejä – jotta malli osaa tunnistaa niiden piirteet oikein.

