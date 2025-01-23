# NLP Project

## Author

- Fanny Renko

## Project Summary

This project explores the use of deep learning for text classification. The goal is to develop a model capable of categorizing various text types, such as Amazon and IMDb reviews, social media posts, and SMS messages. Both deep learning models (e.g., LSTM) and traditional machine learning methods (e.g., Random Forest) are utilized to compare performance.

## Technologies Used
- **Programming Language**: Python
- **Libraries**: Scikit-learn (Random Forest), TensorFlow/Keras (LSTM), Pandas, NumPy, Matplotlib, Seaborn


## Implementation Plan and Dataset Selection

### Datasets:

 - Twitter Sentiment Analysis
https://www.kaggle.com/datasets/jp797498e/twitter-entity-sentiment-analysis

 - IMDB Dataset of 50K Movie Reviews
https://www.kaggle.com/datasets/harshitshankhdhar/imdb-dataset-of-top-1000-movies-and-tv-shows

- Dataset of SMS messages
https://www.kaggle.com/datasets/leoarruda/documents

- Amazon reviews
https://www.kaggle.com/datasets/kritanjalijain/amazon-reviews

## Deep Learning Implementation

**Data Preparation:** Combined datasets and labeled texts for classification.

**Text Preprocessing:** Tokenized text, padded sequences, and standardized input lengths.

**Model Building:** Developed an LSTM-based neural network with embedding, LSTM, dropout, and dense layers.

**Training:** Used early stopping and validation loss to optimize model performance.

**Evaluation:** Achieved 91% accuracy on the test set, excelling with longer, structured texts (e.g., reviews) but underperforming with shorter, informal texts (e.g., tweets and SMS).

## Results and Analysis

#### LSTM Performance:
| Class | Precision | Recall | F1-Score | Support |
|--------|-----------|--------|----------|---------|
| 0      | 0.98      | 0.98   | 0.98     | 1129    |
| 1      | 0.99      | 0.99   | 0.99     | 1138    |
| 2      | 0.82      | 0.88   | 0.85     | 1103    |
| 3      | 0.86      | 0.80   | 0.83     | 1089    |
| **Accuracy** |       |        | **0.91** | **4459**  |
| **Macro Avg** | 0.91  | 0.91  | 0.91     | 4459    |
| **Weighted Avg** | 0.92 | 0.91  | 0.91     | 4459    |


## Recommendations for Improvement

- **Text Preprocessing Enhancements:** Improve handling of slang and abbreviations.
- **Vocabulary Expansion:** Adapt for informal text styles.
- **Alternative Models:** Experiment with CNN-LSTM or pretrained models like BERT or GPT.
- **Optimization:** Fine-tune hyperparameters and adjust training settings.

## Conclusion

The project effectively demonstrated how deep learning, particularly LSTM, can be applied to text classification tasks. While the model achieved excellent results on structured text, additional preprocessing and optimization could further enhance performance for informal and short text types.