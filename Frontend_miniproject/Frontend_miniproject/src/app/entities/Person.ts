import { ISocialAccounts } from "./SocialAccounts";
import { ISocialSkills } from "./SocialSkills";

export interface IPerson {
    id?: number;
    firstname: string
    lastname: string;
    socialSkills: ISocialSkills[];
    socialAccounts : ISocialAccounts[];
}