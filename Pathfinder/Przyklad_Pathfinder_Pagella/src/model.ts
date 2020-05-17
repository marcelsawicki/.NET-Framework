export class MessageEntity {
  userId: number;
  id: number;
  title: string;
  body: string;

  constructor(gitHubMember: { userId: number; id: number; title: string; body: string; }) {
    this.userId = gitHubMember.userId;
    this.id = gitHubMember.id;
    this.title = gitHubMember.title;
    this.body = gitHubMember.body;
  }
}