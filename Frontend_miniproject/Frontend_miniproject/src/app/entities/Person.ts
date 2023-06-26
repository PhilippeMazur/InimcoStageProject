import { SocialAccounts } from "./SocialAccounts";
import { SocialSkills } from "./SocialSkills";

export interface Person {
    id?: number;
    firstname: string
    lastname: string;
    socialSkills: SocialSkills[];
    socialAccounts : SocialAccounts[];
}