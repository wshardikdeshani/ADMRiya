# ADM - Airline Debit Memo Management Tool

## Project Introduction

ADM is used to manage airline debit memos using airline ticket numbers or airline IATA numbers.

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

      /*BAKUP DRIVE PATH PENDING*/

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
