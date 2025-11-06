# JournalApp To-Do List

## Authentication & Identity
- [ ] Integrate Microsoft Entra ID authentication in MAUI app
 - [ ] ? Register app in Azure Entra ID (App registrations) *(user action required)*
 - [ ] ? Provide ClientId, TenantId, and RedirectUri in code via environment variables or user secrets *(user action required)*
 - [ ] ? Configure required API scopes in Azure and code *(user action required)*
- [x] Implement login and logout flows
 - [x] Add logout button and logic in LoginPage
- [ ] Secure token management and validation
 - [ ] Use SecureStorage for access token
 - [ ] Add platform-specific configuration for SecureStorage if needed

## Daily Journaling
- [ ] Display AI-generated daily prompt to user
 - [ ] Populate prompt library with365 prompts, divided equally among categories *(user action required: fill in prompts)*
 - [ ] Provide AI Agent API endpoint and credentials for prompt generation *(user action required)*
- [ ] Enforce one entry per day constraint
- [ ] Implement2-minute writing timer with auto-save
- [ ] Create journal entry interface (text input, timer, progress indicator)
- [ ] Save journal entry draft during writing

## Mood Selection
- [ ] Build mood selection UI (emoji faces)
- [ ] Associate selected mood with journal entry
- [ ] Enforce mood selection before submission

## Journal Entry Submission
- [ ] Validate entry completeness and mood selection
- [ ] Save entry to Azure Storage Blob (immutable after submission)
- [ ] Award experience points and update daily streak
- [ ] Lock app for the day after submission

## Calendar & History
- [ ] Implement calendar view with color-coded days by mood
- [ ] Retrieve and display past entries (read-only)
- [ ] Enable selection of days to view prompt, response, mood, and timestamp

## Mood History & Analytics
- [ ] Visualize mood trends and patterns over time
- [ ] Retrieve and display mood history from storage

## Progress & Gamification
- [ ] Display accumulated experience points (XP)
- [ ] Show daily streak count and progress
- [ ] Track and visualize writing progress during timer

## Backend Services
- [ ] Implement AI Agent Service for prompt generation
- [ ] Integrate with Azure Storage Blob for data persistence
- [ ] Ensure secure, encrypted storage and access control
- [ ] Provide backend API base URL in ApiClientService
 - [ ] ? Set environment variable or user secret for API base URL *(user action required)*
- [ ] Implement backend endpoints for prompt, journal entry, mood, XP, streak, calendar, and history
- [ ] Connect MAUI/Blazor clients to backend using authenticated requests

## Security & Scalability
- [ ] Enforce HTTPS for all API calls
- [ ] Require authentication tokens for backend requests
- [ ] Isolate and control user data access
- [ ] Ensure Azure services are scalable and secure

## Testing & Validation
- [ ] Write unit and integration tests for all major features
- [ ] Validate use case flows and constraints
- [ ] Test authentication, journaling, mood selection, calendar, XP, and streak features

## Documentation
- [ ] Document API endpoints, data models, and authentication flows
- [ ] Update system diagram and use case documentation as needed
