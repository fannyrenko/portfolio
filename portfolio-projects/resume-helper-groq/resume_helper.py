from pathlib import Path
import groq
from bs4 import BeautifulSoup
from datetime import datetime


# Function to extract job details dynamically from HTML
def extract_job_details_dynamic(html_path):
    try:
        with open(html_path, 'r', encoding='utf-8') as f:
            html = f.read()
        soup = BeautifulSoup(html, 'html.parser')

        # Extract job title (heuristic search)
        job_title = next(
            (tag.get_text(strip=True) for tag in soup.find_all(['h1', 'h2', 'h3']) if 'job' in tag.get_text(strip=True).lower()),
            "Unknown"
        )

        # Extract company name (heuristic search)
        company_name = next(
            (tag.get_text(strip=True) for tag in soup.find_all(['h2', 'h3', 'p']) if 'company' in tag.get_text(strip=True).lower()),
            "Unknown"
        )

        # Extract job attributes (list items in bullet points)
        attributes = [li.get_text(strip=True) for ul in soup.find_all(['ul', 'ol']) for li in ul.find_all('li')]
        attributes = attributes if attributes else ["No specific attributes found"]

        return {"job_title": job_title, "company_name": company_name, "attributes": attributes}
    except Exception as e:
        print(f"Error extracting job details: {e}")
        return {}


# Function to summarize job details
def summarize_job_details(details):
    return f"""
    Job Title: {details['job_title']}
    Company: {details['company_name']}
    Key Attributes:
    - {', '.join(details['attributes'][:5])}  # Limit to the first 5 attributes
    """.strip()


# Function to load skills from Markdown
def load_skills(md_path):
    try:
        with open(md_path, 'r', encoding='utf-8') as f:
            return f.read()
    except FileNotFoundError:
        print(f"Markdown file {md_path} not found.")
        return ""
    except Exception as e:
        print(f"Error loading skills: {e}")
        return ""


# Function to save matched skills to a Markdown file
def save_matched_skills(skills, job_title):
    timestamp = datetime.now().strftime('%Y%m%d_%H%M%S')
    file_name = f"matched_skills_{job_title.replace(' ', '_')}_{timestamp}.md"
    try:
        with open(file_name, 'w', encoding='utf-8') as f:
            f.write(skills)
        print(f"Matched skills saved to '{file_name}'")
    except Exception as e:
        print(f"Error saving matched skills: {e}")


# Main script
if __name__ == '__main__':
    resumes_folder = Path('./resumes')

    # Find the first .htm file in the folder
    try:
        resume_path = next(resumes_folder.glob('*.htm'))
    except StopIteration:
        print("No .htm files found in the 'resumes' folder.")
        exit(1)

    job_details = extract_job_details_dynamic(resume_path)
    if not job_details:
        print("Failed to extract job details.")
        exit(1)

    job_summary = summarize_job_details(job_details)
    skills = load_skills('./default_resume.md')

    if not skills:
        print("No skills found in the resume. Exiting.")
        exit(1)

    # Initialize Groq client and prepare prompts
    groq_client = groq.Client()
    match_skills_prompt = f"""
    You are a professional resume writer. Based on the job description below, 
    extract only the directly relevant skills from the provided resume that match the job requirements. 
    For each skill, provide a short explanation of why it is relevant to the job description.

    Job Description:
    {job_summary}

    Resume Skills:
    {skills}
    """


    messages = [
        {'role': 'system', 'content': "You are a professional resume writer."},
        {'role': 'user', 'content': match_skills_prompt}
    ]

    # Call Groq API to get matched skills
    try:
        skill_match_completion = groq_client.chat.completions.create(
            messages=messages,
            model="mixtral-8x7b-32768",
            stream=False
        )
        matched_skills = skill_match_completion.choices[0].message.content
        print("\nMatched Skills:\n", matched_skills)

        # Save the matched skills to a Markdown file
        save_matched_skills(matched_skills, job_details['job_title'])
    except Exception as e:
        print(f"Error generating matched skills: {e}")
