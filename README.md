# ADM - Airline Debit Memo Management Tool

## Project Introduction

ADM is used to manage airline debit memos using airline ticket numbers or airline IATA numbers.

## Project Owner Details

CTO: Amol Patil
For CTO contact please ask Sagar Bhai

Project Manager: Harshit Gor

  - Mobile No: 99203 68031
  - Email ID: harshit.gor@riya.travel

Team Leader and Sr. Developer: Ketan Hiranandani

  - Mobile No: 99305 91395
  - Email ID: ketan.hiranandani@riya.travel

Hidden person Purav give us this idea to make this project.

## Riya Policy

  1. They give us one remote server for an access database of ADM. This remote server opens from our 109 IP server because he needs some static IP that's why we give 109 servers.

  2. Upload all ADM code using Ankh SVN and Tortoise SVN in his server.

  3. For live database access, we need to call Ketan Hiranandani first if he is not available then call Harshit Gor. Because they have some policy for live database access.

  4. For upload changes first commit all work in Ankh SVN to his server then call Ketan Hiranandani for upload website. They have 2 sites for upload 1 is parikshan and 1 is life. So first they upload our work in parikshan if it is proper then they upload in Live Server.

  5. You can get all the changes by a phone call or in email. Every time Harshit Gor gives us changes because he is project manager.

## Why ADM

ADM is (Airline Debit Memo). If Airline found some violation in ticket booking they send ADM to that user.

Riya maintains all the ADM in live google sheet. Nowadays work is a little painful so they decide to make this system. This system is phase 1 and currently, this is launched in some branches.

## Projects Inside ADM

1. ADMPro (MVC website)

  - SQLClass, SQLLogic, SQLHelper added as a reference in this project.

3rd Party DLL

  - NPOI

    - Use: Generate and export excel sheet. Download from the NuGet package. Version 2.4.1

  - Newtonsoft.Json

    - Use: To generate and return JSON. Download from the NuGet package. Version 12.0.3

2. SQLClass (All types of table classes added)

3. SQLLogic (All types of insert/update/delete logic write here)

    - SQLClass and SQLHelper added as a reference in this project for CRUD operation.

4. SQLHelper (Websmith framework do connection with database)

**3rd Party DLL**

  - Newtonsoft.Json

    - Use: To generate and return JSON. Download from the NuGet package. Version 12.0.3

  - System.Configuration

    - Use: To get values from the web.config file.

## Login URL

**URL: https://airlineinfo.oneriya.com/AirlineData/Home**

Login via the above URL into ADM.

**Note: For a login to ADM using Employee code given by Riya.**

4 types of URL create in the project for role wise login.

**Audit Manager (Role 1)**

1. http://adm.oneriya.com/Home/Index?eid=010247&enm=Anish&role=1

**Audit User (Role 2)**

2. http://adm.oneriya.com/Home/Index?eid=010247&enm=Anish&role=2

**Branch Manager (Role 3)**

3. http://adm.oneriya.com/Home/Index?eid=010247&enm=Anish&bnm=Mumbai&role=3

**Branch User (Role 4)**

4. http://adm.oneriya.com/Home/Index?eid=010247&enm=Anish&bnm=Mumbai&role=4

## Source Control

For this project, we use 2 source control.

  1. Github (Websmith Account)

  2. AnkhSVN (Riya Account)

## Project Configuration

  .Net Framework 4.6.1

  Project created in Visual Studio 2017

**Note: Our system SQL server and ADM live SQL server version are different. So be careful while uploading DB in live version.**

## Project Live Process

For Websmith

  - If you need to upload a project in our server first create a new database and sub-domain for upload project.

For Riya

  - Commit project change in Riya SVN

  - To add AnkhSVN download from the visual studio extensions and updates. Follow the below steps.

    Step 1: Open visual studio 2017

    Step 2: Go to Tools -> Extensions and Updates

    Step 3: Search **AnkhSVN** and install

  - To add TortoiseSVN

    Download from below the backup drive path.

      https://drive.google.com/open?id=1GqZWtWl6h_eD1f-C3HMZEaecBJJONncp

## Modules

###### Dashboard

- Display status wise ticket count
- Filter tickets if user click on the status
- Filter tickets by ticket number, ADM raised to date, status, reason, and branch wise
- Role wise manage dashboard ticket table
- Add new ADM from the dashboard
- Export data to excel

###### View Follow Up

- Users can see all follow-ups added by other users.
- Users can add new follow up from view follow up the screen.
- In this screen, we display ticket details that added in ADM.

###### ADM Master

- Add new ADM
- Search ADM using ticket/IATA wise
- Upload single file while adding new ADM
- Change status active/deactivate of ADM record
- Soft ADM delete
- Edit ADM

**Note: If new ADM raised we send an email to that branch with the ADM detail. For getting emails we use "Branch Email Master".**

###### Reason Master

- There some fixed reasons for getting ADM so here we create a master for that. With Add/Edit/Delete functions.

###### Status Master

- There are some fixed statuses to manage ADM. So we create a status master with Add/Edit functions.

  **Use Of Status**

  - New

    - Use: By default select this status when raised a new ADM.

  - Pending

    - Use: If the user starts working on the ADM he set status pending. It means users take this ADM and start working on it.

  - Debit to Riya

    - Use: If the main status is **ACM Received** then the user can select this status. The use of this status is to manage the ADM amount is e.g. Total ADM is 5000 and the ACM Received **(Refund by airline)** 3000 then what about 2000 at that time user select Debit to Riya it means 2000 debit from **Riya** account.

  - Debit to Sub Agent

    - Use: If the main status is **ACM Received** then the user can select this status. The use of this status is to manage the ADM amount is e.g. Total ADM is 5000 and the ACM Received **(Refund by airline)** 3000 then what about 2000 at that time user select Debit to Sub Agent it means 2000 debit from **Sub Agent** account.

  - Dispute

    - Use: In this status no effect with the record.

  - ACM Received

    - Use: ACM Received means get a refund from the airline. Now after this status there is 2 sub status of this record.

      1. Partial ACM Received - Debit to Riya
      2. Partial ACM Received - Debit to Sub Agent

      **Note: use of these statuses already added**

  - ADM Deleted

    - Use: Set ADM record status as ADM Deleted

  - Partial ACM Received - Debit to Riya

    - Use: If ADM status is ACM Received then we display sub status dropdown in follow up dialog. If the user selects this status we display another dialog for select debit from **Staff/Riya** If the user selects Staff then displays one empty box for manually write the staff name. If select Riya then by default set **Company Account** in the database.

    - e.g. If ADM total amount is 5000 and ACM received 3000. So who is responsible for these 2000. If Riya debit this amount from the sub-agent account then sub-agent say I am not responsible for that amount or I am not paying this amount. So Riya gives the option to sub-agent. Part this 2000 and tell sub-agent that 1000 cut from your account. And the remaining (amount) 1000 cut from Riya's account or staff salary.

  - Partial ACM Received - Debit to Sub Agent

    - Use: If ADM status is ACM Received then we display sub status dropdown in follow up dialog. If the user selects this status we display another dialog for select debit from **Sub Agent**  then display one empty box for manually write the sub-agent name. It means some amount cut from a sub-agent account and the remaining amount cut from Riya's account by default

    - e.g. If ADM total amount is 5000 and ACM received 3000. So who is responsible for these 2000. If Riya debit this amount from the sub-agent account then sub-agent say I am not responsible for that amount or I am not paying this amount. So Riya gives the option to sub-agent. Part this 2000 and tell sub-agent that 1000 cut from your account. And the remaining (amount) 1000 cut from Riya's account.

###### Branch Email Master

- In branch email master when ADM raised we need to send emails to respective branches. Here we load already exists branch from the maintained database. So the user can filter that branch and update To and CC email of that branch.

## User Roles

- Audit Manager
- Audit User
- Branch Manager
- Branch User

###### Audit Manager

The audit Manager is one type of super admin. In this user, role user can see all the tickets in his dashboard with respective status. Also, Search ticket by ticket number, from to date of ADM raised to date, status wise, Branch wise and reason wise.

In the audit manager dashboard, we display status, wise ticket count. If the user clicks on this count at the below table we filter that status count records.

Also, the audit manager can add new ADM and manage all masters.

Audit managers only see all followups added by the branch manager, branch user, and audit user.

###### Audit User

Audit users can see all the branches ticket count on the dashboard and all branch tickets display in a table with right of view all follow-ups. Also, audit user can add new follow up.

Also, the Audit user manages all masters like audit managers.

###### Branch Manager

The branch manager can see tickets of their own branch with a status count display on the dashboard. Also, display all tickets of their own branch in the table can see.

Branch manager rights are added new follow-ups and view follow-ups added by other users and another branch user can see.

###### Branch User

Branch user can see their branch tickets and manage tickets. Also, add new follow-ups and see other users' follow-ups.

## Website Screenshots

###### 1. ADM Dashboard Count Display

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/DashboardCount.png)

In the above screenshot, role and branch wise display count of the status.

Also, When the user clicks on any status count on the same page we filter records of that status.

###### 2. ADM Dashboard Search Box

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/DashboardSearchBox.png)

In the above screenshot, role and branch wise display search box. Here use can filter records using Ticket No, From and To Date, Status, Reason, and Branch wise.

Also, If a user from the branch (Note: Role is 3 = Branch Manager or 4 = Branch User) then we do not display a branch search box.

###### 3. ADM Dashboard All Tickets

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/DashboardAllADMTable.png)

In the above screenshot, role wise display table data

e.g.

  1. If the user role is 1 = Audit Manager or 2 = Audit user they can see all tickets.

  2. If the user role is 3 = Branch Manager or 4 = Branch user they can see his branch tickets.

Also, 1 = Audit Manager and 2 = Audit user have permission to add new ADM and 3 = Branch Manager and 4 = Branch user can not add new ADM that's we do not display button of add new ADM in a Branch Manager role and branch user role (in 3 and 4).

###### 4. ADM Dashboard Add New ADM

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/DashboardAddNewADMDialog.png)

In the above screenshot, 1 = Audit Manager and 2 = Audit User only can add new ADM.

In this dialog, the user can search ticket detail using Ticket No or IATA number (IATA full form is International Air Transport Association. Please refer to this wiki link https://en.wikipedia.org/wiki/International_Air_Transport_Association). When a user clicks on search at that time we use 3 databases of RIYA that collect this ticket detail from his sources.

  1. DBAIR
  2. DSR_ERP
  3. TicketAudit

We take Office ID, Branch ID, Ticket Amount from above sources and display dialog's field.

Once we get detail audit user or manager add ADM No, ADM Amount and IATA ADM Date (This field used for in which day ADM Raised. Why we use this field because get some delay fro getting ADM to us) and Reason with some remarks by audit user or manager. Also, we give one file upload option.

After the above steps when the user clicks on save we get that branch emails and send this ADM detail mail to that branch. and this ADM starts displaying in the Audit User and Manager dashboard with that specific branch user and manager's dashboard with the status "NEW".

###### 5. ADM Dashboard Add New Followup

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/DashboardAddNewFollowup.png)

In the above screenshot, Except for the audit manager, all users can add a new followup.

In this dialog, the user can see audit user or manager's remarks and they can add his remarks next follow update and status.

When users add new followup they can select any status. Now here I discuss status again in the short description.

    1. New - Display when audit user and manager add new ADM.
    2. Pending - When a user adds a new followup and the ADM not resolved. Then they can select a pending status for further process ADM.
    3. Debit to Riya - If ADM is not resolved and the amount not gets a refund then they select this status. There one simple logic here if you select Debit to Riya we display one box. Who is responsible for this ADM staff or Riya. If select Riya then it's done here and if selected staff then they need to add staff name in another open box.
    4. Debit to Sub Agent - If ADM is not resolved and the amount not gets a refund then they select this status. Also, here one logic if the user selects this status then they need to add Agent name in open box. Because for this ADM sub-agent is responsible for this ADM.
    5. Dispute - Means there some issue with the ADM so they select this status.
    6. ACM Received - Means ADM is resolved and the amount gets refund then the user selects this status. When selecting this status we display the ADM amount, ACM No, ADM Amount and the diff of the ADM and ACM amount. If the ACM diff is greater then 0 means ACM does not refund the full amount at that time we display Partial status.
    
      a. Partial ACM Received - Debit to Riya - Please refer "Partial ACM Received - Debit to Riya" here I add detail and example of why select this status.
      b. Partial ACM Received - Debit to Sub Agent - Please refer "Partial ACM Received - Debit to Sub Agent"  here I add detail and example of why select this status.

###### 6. ADM Deleted - Means ADM is currently not used full so they select this status. In this status, we are not deleting the record just change the status.

###### 6. View Followups

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/ViewFollowUps.png)

In the above screenshot, We display ticket detail and all the followups give by all users. From this screen, the user can add new followups also.

###### 7. Reason Master

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/ReasonMaster.png)

In the above screenshot, users can add/edit reasons.

###### 8. Status Master

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/StatusMaster.png)

In the above screenshot, users can add/edit status.

###### 9. Branch Email Master

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/BranchEmailMaster.png)

In the above screenshot, Here we get data from DBADM and DSR_ERP database. We union both table and display all branches with email. So here the user edits the branch and adds To email and CC email in comma-separated.

Note: We use this master to send an ADM email to a specific branch while the new ADM raised.

###### 10. Role wise menu

![alt text](https://raw.githubusercontent.com/wshardikdeshani/ADMRiya/master/ADMPro/WebImageAndDoc/RoleWiseMenu.png)

In the above screenshot, Display menu role wise. If the user role is 1 = Audit Manager and 2 = Audit user they have the permission of all the menu with masters. If the user role is 3 = Branch Manager and 4 = Branch User they have permission for seeing Dashboard.

###### Here I attached one excel sheet that is export from Dashboard [Exported Excel Sheet Downlod From Here](https://github.com/wshardikdeshani/ADMRiya/blob/master/ADMPro/WebImageAndDoc/637214460340569127.xls?raw=true).
