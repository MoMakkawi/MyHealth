# MyHealth

### Summary :
A API for the patient to be aware of his medical record, the doctor is aware of the patients' medical record after taking their consent

### General idea :
This API is responsible for transferring data, as there are 3 roles,
the first role is for the patient, where he has the right to see his sick record and agree, reject or ignore the doctor’s request,
and here we see that the second role is played by the doctor, 
so that no doctor has the right to see any patient’s information due to the consideration of privacy Patients,
if a doctor wants to see a patient's information, this doctor must submit a request to the patient 
and wait for his approval (the patient's consent) so that this doctor is able to see his information (patient information). 
To check the registrant on the site if he claims to be a doctor. 
This will be done when the registrant on this site uploads a certificate 
proving that he is a doctor or an equivalent so that the project manager can confirm that he is a doctor.

### About techniques :
#### You will see many techniques that were used in this project some of them are: Restful API , CQRS pattern , mediatr pattern , automapper , user management , entity framework .

### System Modeling :

![Use Case Diagrams](https://user-images.githubusercontent.com/94985793/223983306-0a7bac53-87f0-4dfc-addd-a7d6f3a16c41.jpg)
![Dr Account Register Sequence Diagram](https://user-images.githubusercontent.com/94985793/223983362-50474eb6-92ca-40a6-b223-6bbf244603b5.jpg)
![Try Access to patent information Sequence Diagrams](https://user-images.githubusercontent.com/94985793/223983371-d9f8c2aa-e805-4466-95c3-ed28167737ca.jpg)
