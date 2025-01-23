# Fake News Classification with LinearSVC

This project aimed to build a model to classify news articles as real or fake using a LinearSVC classifier. The goal was to predict the authenticity of news articles based on their textual content.

Data used in this project is from Kaggle, Fake News Detection data:

  https://www.kaggle.com/code/therealsampat/fake-news-detection/notebook

**Steps Taken:**

  - ***Preparing the Data:***
    - Text Conversion: Used a method called TF-IDF to turn the text into numbers that the model can understand. I also removed common words (like "the" and "is") to make the data cleaner.
    - Data Split: I divided the data into two parts: 80% for training the model and 20% for testing it.

  - ***Creating the Model:***
    - Trained the LinearSVC model using the training data.

  - ***Evaluating the Model:***
    - The model got 99% accuracy on the test data and also showed a 99% average score when tested with different parts of the data (5-fold cross-validation).
    - The model performed very well in identifying both fake and real news.

**Tools Used:**

  - Python, Scikit-learn, TfidfVectorizer, LinearSVC

**Results:**

  - ***Accuracy:*** The model was 99% accurate on the test data and performed consistently well across all tests.
  - ***Balanced Results:*** The model worked well for both real and fake news, with high precision and recall for both categories.